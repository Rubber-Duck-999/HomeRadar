// <copyright file="DeviceScan.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
  using System;
  using System.Collections.Generic;
  using System.Net;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Net.NetworkInformation;
  using System.Net.Sockets;
  using System.Text;
  using System.Threading;

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

    /// <summary>
    /// The following method gets the name of the NIC vendor.
    /// </summary>
    /// <param name="mac">NIC mac address.</param>
    /// <returns>NIC vendor name.</returns>
    public string GetVendor(string mac)
    {
      var client = new HttpClient
      {
        BaseAddress = new Uri("https://api.macvendors.com/"),
      };

      // Add an Accept header for JSON format.
      client.DefaultRequestHeaders.Accept.Add(
      new MediaTypeWithQualityHeaderValue("application/json"));

      // List data response.
      // ToDo: Why are we waiting here?
      Thread.Sleep(2000);
      HttpResponseMessage response = client.GetAsync(mac).Result;

      // Blocking call! Program will wait here until a response is received or a timeout occurs.
      string vendor = null;
      if (response.IsSuccessStatusCode)
      {
        // Parse the response body.
        vendor = response.Content.ReadAsStringAsync().Result;
      }
      else
      {
        Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
      }

      // Make any other calls using HttpClient here.
      // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
      // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
      client.Dispose();

      return vendor;
    }
  }
}