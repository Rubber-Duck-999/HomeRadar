// <copyright file="NetworkStateUtil.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
  using System;

  /// <summary>
  /// Provides util methods for the NetworkState class.
  /// </summary>
  public class NetworkStateUtil
  {
    /// <summary>
    /// Prints the wifi details.
    /// ToDo: I think this can be removed.
    /// </summary>
    /// <param name="networkState">Details to print.</param>
    public static void PrintAll(NetworkState networkState)
    {
      Console.WriteLine("Host Name: " + networkState.HostName);
      Console.WriteLine("Wifi Name: " + networkState.NetworkName);
      Console.WriteLine("Operating System: " + networkState.OperatingSystem);
      Console.WriteLine("Status: " + networkState.OperationalStatus);
      Console.WriteLine("MAC Address: " + networkState.MacAddress);
      Console.WriteLine("IPV6: " + networkState.Ipv6);
      Console.WriteLine("IPV4: " + networkState.Ipv4);
      Console.WriteLine("IPV4 Subnet mask: " + networkState.Ipv4Mask);
      Console.WriteLine("Vendor of Device: " + networkState.Vendor);
      Console.WriteLine("Broadcast Address: " + networkState.BroadcastAddress);
    }
  }
}