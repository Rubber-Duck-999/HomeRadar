// <copyright file="DeviceScanTest.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Tests.DeviceScan
{
  using System.Net.NetworkInformation;
  using FluentAssertions;
  using Xunit;
  using DeviceScan = Core.DeviceScan;

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
      DeviceScan scan = new DeviceScan();
      Assert.True(string.IsNullOrEmpty(scan.network_adapter.HostName));
      Assert.Equal("WINDOWS", scan.network_adapter.OperatingSystem.ToString());
      scan.network_adapter.OperatingSystem.ToString().Should().Be("WINDOWS");


      // Act
      // Run scan
      scan.GetDeviceDetails();

      // Assert

      // ToDo: Note - Assertions should be
      // Assertion(expected, actual);

      // Strings should be set
      Assert.False(string.IsNullOrEmpty(scan.network_adapter.HostName));
      Assert.False(string.IsNullOrEmpty(scan.network_adapter.NetworkName));
      Assert.False(string.IsNullOrEmpty(scan.network_adapter.Ipv4));
      Assert.False(string.IsNullOrEmpty(scan.network_adapter.MacAddress));

      // These assertions are the same as the above but use the Fluent Assertions framework.
      // I think they are nicer to read.
      // Up to you whether you use fluent assertions or standard xUnit, I prefer fluent.
      string.IsNullOrEmpty(scan.network_adapter.HostName).Should().BeFalse();
      string.IsNullOrEmpty(scan.network_adapter.NetworkName).Should().BeFalse();
      string.IsNullOrEmpty(scan.network_adapter.Ipv4).Should().BeFalse();
      string.IsNullOrEmpty(scan.network_adapter.MacAddress).Should().BeFalse();

      // Status should be up
      Assert.Equal(OperationalStatus.Up, scan.network_adapter.OperationalStatus);
      scan.network_adapter.OperationalStatus.Should().Be(OperationalStatus.Up);

      scan.FindDevices();
    }
  }
}
