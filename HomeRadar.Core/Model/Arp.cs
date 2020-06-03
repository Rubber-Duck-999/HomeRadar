// <copyright file="Arp.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
  using System.Collections.Generic;
  using System.Diagnostics;

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
    /// Initializes a new instance of the <see cref="Arp"/> class.
    /// </summary>
    public Arp()
    {
      // ToDo: What is the reply address and where do we get it from?
      this.pProcess = new System.Diagnostics.Process
      {
        StartInfo =
        {
          FileName = "arp",
          Arguments = "-a " /*+ reply.Address,*/,
          UseShellExecute = false,
          RedirectStandardOutput = true,
          CreateNoWindow = true,
        },
      };
    }

    /// <summary>
    /// The following method finds the devices on the network.
    /// </summary>
    /// <returns>A dictionary of devices.</returns>
    public Dictionary<uint, Device> FindDevices()
    {
      this.RunArpProcess();

      var temp = new Dictionary<uint, Device>();
      string strOutput = this.pProcess.StandardOutput.ReadToEnd();
      string[] substrings = strOutput.Split('-');
      var macAddress = ArpUtil.GetMacAddress(substrings);

      /*
      if (reply.Address.ToString() == this.network_adapter.Ipv4)
      {
        mac_address = this.network_adapter.MacAddress;
      }
      Device local = new Device(mac_address, reply.Address.ToString(), vendor);
      */

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