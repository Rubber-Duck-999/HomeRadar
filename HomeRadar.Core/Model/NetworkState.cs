// <copyright file="NetworkState.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core
{
  using System;
  using System.Net.NetworkInformation;
  using System.Runtime.InteropServices;

  /// <summary>
  /// The following class contains Wifi State.
  /// ToDo: I think we'll need a contract, service, and platform specific implementations to complete this.
  /// </summary>
  public class NetworkState
  {
    public NetworkState() 
    { 
      this.FindOS();
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
    private void FindOS()
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
    /// Prints the wifi details.
    /// ToDo: I think this can be removed.
    /// </summary>
    public void PrintAll()
    {
      Console.WriteLine("Host Name: " + this.HostName);
      Console.WriteLine("Wifi Name: " + this.NetworkName);
      Console.WriteLine("Operating System: " + this.OperatingSystem);
      Console.WriteLine("Status: " + this.OperationalStatus);
      Console.WriteLine("MAC Address: " + this.MacAddress);
      Console.WriteLine("IPV6: " + this.Ipv6);
      Console.WriteLine("IPV4: " + this.Ipv4);
      Console.WriteLine("IPV4 Subnet mask: " + this.Ipv4Mask);
      Console.WriteLine("Vendor of Device: " + this.Vendor);
      Console.WriteLine("Broadcast Address: " + this.BroadcastAddress);
    }

    /// <summary>
    /// Calculates the broadcast address.
    /// </summary>
    private void CalculateBroadCast()
    {
        var ip_block = this.Ipv4.Split(' ');
        if (this.Ipv4Mask == "255.255.255.0")
        {
          ip_block[3] = "255";
        }

        string address = ip_block[0] + "." + ip_block[1] + "." + ip_block[2] + "." + ip_block[3];
        this.BroadcastAddress = address;
    }
  }
}