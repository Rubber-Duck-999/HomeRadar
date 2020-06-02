// <copyright file="Arp.cs" company="FutureInnovationTech">
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

    public class Arp
    {
        public Arp()
        {
            pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a " + reply.Address;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
        }

        private System.Diagnostics.Process pProcess { get; set; }
        
        public Dictionary<uint, Device> FindDevices() 
        {
            pProcess.Start();
            Dictionary<uint, Device> temp = new Dictionary<uint, Device>();
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
            Device local = new Device(mac_address, reply.Address.ToString(), vendor);
        }
    }
}