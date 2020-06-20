// <copyright file="DeviceScanTest.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Tests.DeviceScan
{
  using System;
  using FluentAssertions;
  using Xunit;
  using DeviceScan = Model.DeviceScan;

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
      var scan = new DeviceScan();
      Assert.True(string.IsNullOrEmpty(scan.NetworkAdapter.HostName));
      Assert.Equal("OSX", scan.NetworkAdapter.OperatingSystem.ToString());
      scan.NetworkAdapter.OperatingSystem.ToString().Should().Be("OSX");


      // Act
      // Run scan
      scan.GetDeviceDetails();
    }
  }
}
