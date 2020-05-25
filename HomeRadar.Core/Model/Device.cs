using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net; //Include this namespace  
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections;
using System.Threading;

namespace HomeRadar.Core
{
    class Device
    {
        public Device(string Mac, string IP, string Manufacturer)
        {
            MacAddress = Mac;
            Ipv4 = IP;
            Vendor = Manufacturer;
        }

        public string Vendor { get; set; }

        public string MacAddress { get; set; }

        public string Ipv4 { get; set; }

        public string OperatingSystem { get; set; }

        public bool Ssh { get; set; }

        public uint SshPort { get; set; }

        public bool Sql { get; set; }

        public bool SqlPort { get; set; }
    }
}