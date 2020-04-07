using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net; //Include this namespace  
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace NetworkChecker
{
    class Wifi
    {
        public Wifi()
        {

        }


        private string wifiName;
        public string Name
        {
            get { return wifiName; }
            set { wifiName = value; }
        }

        private OperationalStatus status;

        public OperationalStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        private string mac;

        public string Mac
        {
            get { return mac; }
            set { mac = value; }
        }

        private string ipv_six;

        public string Ipv_six
        {
            get { return ipv_six; }
            set { ipv_six = value; }
        }

        private string ipv_four;

        public string Ipv_four
        {
            get { return ipv_four; }
            set { ipv_four = value; }
        }

        private string ipv_four_mask;

        public string Ipv_four_mask
        {
            get { return ipv_four_mask; }
            set { ipv_four_mask = value; }
        }

        internal void printAll()
        {
            Console.WriteLine("Name: " + wifiName);
            Console.WriteLine("Status: " + status);
            Console.WriteLine("MAC Address: " + mac);
            Console.WriteLine("IPV6: " + ipv_six);
            Console.WriteLine("IPV4: " + ipv_four);
            Console.WriteLine("IPV4 Subnetmask: " + ipv_four_mask);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String hostName = Dns.GetHostName();
                Console.WriteLine("Computer name :" + hostName);
                //
                IPHostEntry hostInfo = Dns.GetHostByName(hostName);
                // Get the IP address list that resolves to the host names contained in the 
                // Alias property.
                IPAddress[] address = hostInfo.AddressList;
                // Get the alias names of the addresses in the IP address list.
                String[] alias = hostInfo.Aliases;

                Console.WriteLine("Host name : " + hostInfo.HostName);
                Wifi pcWifi = new Wifi();
                foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if(adapter.Name == "WiFi")
                    {
                        pcWifi.Name = adapter.Name;
                        pcWifi.Status = adapter.OperationalStatus;
                        pcWifi.Mac = adapter.GetPhysicalAddress().ToString();
                        foreach (UnicastIPAddressInformation uipi in adapter.GetIPProperties().UnicastAddresses)
                        {
                            //Console.WriteLine("### Address");
                            if ((uipi.Address.ToString().Length >= 25) && (uipi.Address.ToString().Length <= 27))
                            {
                                //Console.WriteLine("Looks like a IPV6 address");
                                //Console.WriteLine(uipi.Address);
                                pcWifi.Ipv_six = uipi.Address.ToString();
                            }
                            else
                            {
                                //Console.WriteLine("Looks like a IPV4 address");
                                //Console.WriteLine(uipi.Address);
                                pcWifi.Ipv_four = uipi.Address.ToString();
                                pcWifi.Ipv_four_mask = uipi.IPv4Mask.ToString();
                            }
                            //Console.WriteLine("Subnet mask {0}", uipi.IPv4Mask);
                        }
                    }
                }

                pcWifi.printAll();
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

            //
        }
    }
}