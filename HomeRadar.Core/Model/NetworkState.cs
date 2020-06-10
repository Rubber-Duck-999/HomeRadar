// <copyright file="NetworkState.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
  using System.Net.NetworkInformation;
  using System.Runtime.InteropServices;

  /// <summary>
  /// The following class contains Wifi State.
  /// ToDo: I think we'll need a contract, service, and platform specific implementations to complete this.
  /// </summary>
  public class NetworkState
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NetworkState"/> class.
    /// </summary>
    public NetworkState()
    {
      this.FindOperatingSystem();
    }

    /// <summary>
    /// Gets or sets the Wifi name.
    /// </summary>
    public string NetworkName { get; set; }

    /// <summary>
    /// Gets or sets the Host name.
    /// </summary>
    public string HostName { get; set; }

    /// <summary>
    /// Gets or sets the Operating System.
    /// </summary>
    public OSPlatform OperatingSystem { get; set; }

    /// <summary>
    /// Gets or sets the Operational Status of the network interface.
    /// </summary>
    public OperationalStatus OperationalStatus { get; set; }

    /// <summary>
    /// Gets or sets the MAC Address for the network interface.
    /// </summary>
    public string MacAddress { get; set; }

    /// <summary>
    /// Gets or sets the IPv6 address.
    /// </summary>
    public string Ipv6 { get; set; }

    /// <summary>
    /// Gets or sets the IPv4 address.
    /// </summary>
    public string Ipv4 { get; set; }

    /// <summary>
    /// Gets or sets the IPv4 subnet mask address.
    /// </summary>
    public string Ipv4Mask { get; set; }

    /// <summary>
    /// Gets or sets the Manufacturer.
    /// </summary>
    public string Vendor { get; set; }

    /// <summary>
    /// Gets or sets the Manufacturer.
    /// </summary>
    public string BroadcastAddress { get; set; }

    /// <summary>
    /// Calls system file to return Operating System.
    /// </summary>
    private void FindOperatingSystem()
    {
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        this.OperatingSystem = OSPlatform.Windows;
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
      {
        this.OperatingSystem = OSPlatform.OSX;
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
      {
        this.OperatingSystem = OSPlatform.Linux;
      }
    }

    /// <summary>
    /// Calculates the broadcast address.
    /// </summary>
    private void CalculateBroadCast()
    {
      var ipBlock = this.Ipv4.Split(' ');

      // ToDo: Remove magic strings and use constants.
      if (this.Ipv4Mask == "255.255.255.0")
      {
        ipBlock[3] = "255";
      }

      var address = ipBlock[0] + "." + ipBlock[1] + "." + ipBlock[2] + "." + ipBlock[3];
      this.BroadcastAddress = address;
    }
  }
}