// <copyright file="DeviceScanTest.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Tests.DeviceScan
{
  using System;
  using FluentAssertions;
  using HomeRadar.Core.Model;
  using System.Net.NetworkInformation;
  using Xunit;

  /// <summary>
  /// Performs tests to confirm if a device is connected to a network.
  /// </summary>
  public class DeviceScanTest
  {
    /// <summary>
    /// Tests if a device is connected to the Internet network the ConnectivityStatusProvider should return true for IsConnected.
    /// </summary>
    [Fact]
    public void DeviceScan_RunArpSuccessfully()
    {
      // Arrange
      HomeRadar.Core.DeviceScan scan = new HomeRadar.Core.DeviceScan();
      Assert.True(string.IsNullOrEmpty(scan.network_adapter.HostName));

      // Run scan
      scan.Run();

      // Strings should be set
      Assert.False(string.IsNullOrEmpty(scan.network_adapter.HostName));
      Assert.False(string.IsNullOrEmpty(scan.network_adapter.NetworkName));
      Assert.False(string.IsNullOrEmpty(scan.network_adapter.Ipv6));
      Assert.False(string.IsNullOrEmpty(scan.network_adapter.Ipv4));

      // Status should be up
      Assert.Equal(scan.network_adapter.OperationalStatus, OperationalStatus.Up);
    }
  }
}
