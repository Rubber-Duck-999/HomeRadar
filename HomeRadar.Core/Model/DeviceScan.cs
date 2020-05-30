// <copyright file="DeviceScan.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;

    public class DeviceScan
    {
        public NetworkState network_adapter;

        private IDictionary<uint, Device> devices;

        public DeviceScan()
        {
            this.network_adapter = new NetworkState();
        }

        private boolean RunNmapSilently()
        {
            return false;
        }

        public void Run()
        {
            try
            {
                this.network_adapter = new NetworkState();
                this.network_adapter.HostName = Dns.GetHostName();
                foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
                {
                    Console.WriteLine(adapter);
                    if (adapter.OperationalStatus == OperationalStatus.Up)
                    {
                        this.network_adapter.NetworkName = adapter.Name;
                        this.network_adapter.OperationalStatus = adapter.OperationalStatus;
                        PhysicalAddress addr = adapter.GetPhysicalAddress();
                        byte[] bytes = addr.GetAddressBytes();
                        this.network_adapter.MacAddress = string.Empty;
                        foreach (UnicastIPAddressInformation uipi in adapter.GetIPProperties().UnicastAddresses)
                        {
                            if ((uipi.Address.ToString().Length >= 25) && (uipi.Address.ToString().Length <= 27))
                            {
                                this.network_adapter.Ipv6 = uipi.Address.ToString();
                            }
                            else
                            {
                                this.network_adapter.Ipv4 = uipi.Address.ToString();
                                this.network_adapter.Ipv4Mask = uipi.IPv4Mask.ToString();
                            }
                        }
                    }
                }

                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;
                this.network_adapter.PrintAll();

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 2;
                string broadcast = this.network_adapter.BroadcastAddress;
                PingReply reply = pingSender.Send(broadcast, timeout, buffer, options);
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = "arp";
                pProcess.StartInfo.Arguments = "-a " + reply.Address;
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.CreateNoWindow = true;
                pProcess.Start();
                this.devices = new Dictionary<uint, Device>();
                string strOutput = pProcess.StandardOutput.ReadToEnd();
                string[] substrings = strOutput.Split('-');
                string mac_address = string.Empty;
                if (substrings.Length >= 8)
                {
                    mac_address = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                                + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                                + "-" + substrings[7] + "-"
                                + substrings[8].Substring(0, 2);

                }
                if (reply.Address.ToString() == this.network_adapter.Ipv4)
                {
                    mac_address = this.network_adapter.MacAddress;
                }

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.macvendors.com/");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                Thread.Sleep(2000);
                HttpResponseMessage response = client.GetAsync(mac_address).Result;

                // Blocking call! Program will wait here until a response is received or a timeout occurs.
                string vendor = null;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    vendor = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                Device local = new Device(mac_address, reply.Address.ToString(), vendor);

                // Make any other calls using HttpClient here.
                // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
                // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
                client.Dispose();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
        }
    }
}