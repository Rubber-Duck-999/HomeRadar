// <copyright file="DeviceScan.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
  using System;
  using System.Collections.Generic;
  using System.Net;

  using System.Net.NetworkInformation;
  using System.Net.Sockets;
  using System.Text;

  /// <summary>
  /// The following class handles the network scan.
  /// </summary>
  public class DeviceScan
  {
    /// <summary>
    /// Collection of devices on the network.
    /// </summary>
    private IDictionary<uint, Device> devices;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceScan"/> class.
    /// </summary>
    public DeviceScan()
    {
      this.NetworkAdapter = new NetworkState();
    }

    /// <summary>
    /// Gets or sets the Network State.
    /// </summary>
    public NetworkState NetworkAdapter { get; set; }

    /// <summary>
    /// The following method gets the details of network devices.
    /// </summary>
    public void GetDeviceDetails()
    {
      this.NetworkAdapter = new NetworkState();
      this.NetworkAdapter.HostName = Dns.GetHostName();
      foreach (var adapter in NetworkInterface.GetAllNetworkInterfaces())
      {
        if (adapter.OperationalStatus == OperationalStatus.Up)
        {
          this.NetworkAdapter.NetworkName = adapter.Name;
          this.NetworkAdapter.OperationalStatus = adapter.OperationalStatus;
          this.NetworkAdapter.MacAddress = adapter.GetPhysicalAddress().ToString();
          foreach (UnicastIPAddressInformation uipi in adapter.GetIPProperties().UnicastAddresses)
          {
            if ((uipi.Address.ToString().Length >= 25) && (uipi.Address.ToString().Length <= 27))
            {
              this.NetworkAdapter.Ipv6 = uipi.Address.ToString();
            }
            else
            {
              this.NetworkAdapter.Ipv4 = uipi.Address.ToString();
              this.NetworkAdapter.Ipv4Mask = uipi.IPv4Mask.ToString();
            }
          }
        }
      }
    }

    /// <summary>
    /// The following method gets the devices on the network.
    /// </summary>
    public void FindDevices()
    {
      try
      {
        var pingSender = new Ping();
        var arp = new Arp();
        NetworkStateUtil.PrintAll(this.NetworkAdapter);

        // Create a buffer of 32 bytes of data to be transmitted.
        var data = "aaa";
        byte[] buffer = Encoding.ASCII.GetBytes(data);
        PingReply reply = pingSender.Send(
          this.NetworkAdapter.BroadcastAddress,
          2,
          buffer,
          new PingOptions());
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
  }
}