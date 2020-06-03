// <copyright file="DeviceScan.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core
{
  using System;
  using System.Collections.Generic;
  using System.Net;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Net.NetworkInformation;
  using System.Net.Sockets;
  using System.Text;
  using System.Threading;
  using Model;

  public class DeviceScan
  {
    public NetworkState network_adapter;

    private IDictionary<uint, Device> devices;

    public DeviceScan()
    {
      this.network_adapter = new NetworkState();
    }

    public void GetDeviceDetails()
    {
      this.network_adapter = new NetworkState();
      this.network_adapter.HostName = Dns.GetHostName();
      foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
      {
        if (adapter.OperationalStatus == OperationalStatus.Up)
        {
          this.network_adapter.NetworkName = adapter.Name;
          this.network_adapter.OperationalStatus = adapter.OperationalStatus;
          this.network_adapter.MacAddress = adapter.GetPhysicalAddress().ToString();
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
    }

    public void FindDevices()
    {
      try
      {
        Ping pingSender = new Ping();
        Arp arp = new Arp();
        this.network_adapter.PrintAll();

        // Create a buffer of 32 bytes of data to be transmitted.
        string data = "aaa";
        byte[] buffer = Encoding.ASCII.GetBytes(data);
        PingReply reply = pingSender.Send(this.network_adapter.BroadcastAddress,
            2, buffer, new PingOptions());
        this.devices = arp.FindDevices();
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

    public string GetVendor(string mac)
    {
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri("https://api.macvendors.com/");

      // Add an Accept header for JSON format.
      client.DefaultRequestHeaders.Accept.Add(
      new MediaTypeWithQualityHeaderValue("application/json"));

      // List data response.
      Thread.Sleep(2000);
      HttpResponseMessage response = client.GetAsync(mac).Result;

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

      // Make any other calls using HttpClient here.
      // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
      // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
      client.Dispose();

      return vendor;
    }
  }
}