// <copyright file="DeviceScanTest.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Tests.DeviceScan
{
  using System.Net.NetworkInformation;
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
      DeviceScan scan = new DeviceScan();
      Assert.True(string.IsNullOrEmpty(scan.NetworkAdapter.HostName));
      Assert.Equal("WINDOWS", scan.NetworkAdapter.OperatingSystem.ToString());
      scan.NetworkAdapter.OperatingSystem.ToString().Should().Be("WINDOWS");


      // Act
      // Run scan
      scan.GetDeviceDetails();

      // Assert

      // ToDo: Note - Assertions should be
      // Assertion(expected, actual);

      // Strings should be set
      Assert.False(string.IsNullOrEmpty(scan.NetworkAdapter.HostName));
      Assert.False(string.IsNullOrEmpty(scan.NetworkAdapter.NetworkName));
      Assert.False(string.IsNullOrEmpty(scan.NetworkAdapter.Ipv4));
      Assert.False(string.IsNullOrEmpty(scan.NetworkAdapter.MacAddress));

      // These assertions are the same as the above but use the Fluent Assertions framework.
      // I think they are nicer to read.
      // Up to you whether you use fluent assertions or standard xUnit, I prefer fluent.
      string.IsNullOrEmpty(scan.NetworkAdapter.HostName).Should().BeFalse();
      string.IsNullOrEmpty(scan.NetworkAdapter.NetworkName).Should().BeFalse();
      string.IsNullOrEmpty(scan.NetworkAdapter.Ipv4).Should().BeFalse();
      string.IsNullOrEmpty(scan.NetworkAdapter.MacAddress).Should().BeFalse();

      // Status should be up
      Assert.Equal(OperationalStatus.Up, scan.NetworkAdapter.OperationalStatus);
      scan.NetworkAdapter.OperationalStatus.Should().Be(OperationalStatus.Up);

      scan.FindDevices();
    }
  }
}
