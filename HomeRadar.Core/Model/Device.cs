// <copyright file="Device.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core
{
    using System;

    public class Device
    {
        public Device(string mac, string ip, string manufacturer)
        {
            this.MacAddress = mac;
            this.Ipv4 = ip;
            this.Vendor = manufacturer;
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