// <copyright file="Arp.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The following class handles Address Resolution.
    /// </summary>
    public class Arp
    {
        /// <summary>
        /// Process for running ARP.
        /// </summary>
        private readonly Process pProcess;

        /// <summary>
        /// Regix pattern for getting ip address and mac address.
        /// </summary>
        private readonly string pattern = @"(?<ip>([0-0]{1,3}\.?){4})\s*(?<mac>([a-f0-9]{2}-/){6})";

        /// <summary>
        /// Initializes a new instance of the <see cref="Arp"/> class.
        /// </summary>
        public Arp()
        {
            this.pProcess = new System.Diagnostics.Process
            {
                StartInfo =
                {
                  FileName = "arp",
                  Arguments = "-a",
                  UseShellExecute = false,
                  RedirectStandardOutput = true,
                  CreateNoWindow = true,
                },
            };
        }

        /// <summary>
        /// Gets or sets Counter for devices.
        /// </summary>
        public uint Counter { get; set; }

        /// <summary>
        /// The following method finds the devices on the network.
        /// </summary>
        /// <returns>A dictionary of devices.</returns>
        public Dictionary<uint, Device> FindDevices()
        {
            this.RunArpProcess();

            var temp = new Dictionary<uint, Device>();
            string strOutput = this.pProcess.StandardOutput.ReadToEnd();
            this.Counter = 0;

            foreach (Match m in Regex.Matches(strOutput, this.pattern, RegexOptions.IgnoreCase))
            {
                string vendor = VendorUtils.GetVendor(m.Groups["mac"].Value);
                Device deviceTemp = new Device(
                    m.Groups["mac"].Value,
                    m.Groups["ip"].Value,
                    vendor);
                temp.Add(this.Counter, deviceTemp);
                this.Counter++;
            }

            return temp;
        }

        /// <summary>
        /// Executes the ARP process.
        /// </summary>
        private void RunArpProcess()
        {
            this.pProcess.Start();
        }
    }
}