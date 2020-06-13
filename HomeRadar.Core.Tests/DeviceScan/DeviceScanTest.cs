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
      Assert.Equal("WINDOWS", scan.NetworkAdapter.OperatingSystem.ToString());
      scan.NetworkAdapter.OperatingSystem.ToString().Should().Be("WINDOWS");


      // Act
      // Run scan
      scan.GetDeviceDetails();

      // Assert

      // ToDo: Note - Assertions should be
      // Assertion(expected, actual);

      // ToDo: Tests should not depend on the platform they run.
      // ToDo: Abstract the platform dependency to an interface so the platform can be plugged in.
      // This will allow us to plug in a test platform at the test stage and use the actual platform at runtime.
      // This also allows us to abstract away code that isn't ours e.g.  NetworkInterface.GetAllNetworkInterfaces() used in 
      // DeviceScan.GetDeviceDetails().

      // Strings should be set
      //Assert.False(string.IsNullOrEmpty(scan.NetworkAdapter.HostName));
      //Assert.False(string.IsNullOrEmpty(scan.NetworkAdapter.NetworkName));
      //Assert.False(string.IsNullOrEmpty(scan.NetworkAdapter.Ipv4));
      //Assert.False(string.IsNullOrEmpty(scan.NetworkAdapter.MacAddress));

      // These assertions are the same as the above but use the Fluent Assertions framework.
      // I think they are nicer to read.
      // Up to you whether you use fluent assertions or standard xUnit, I prefer fluent.
      //string.IsNullOrEmpty(scan.NetworkAdapter.HostName).Should().BeFalse();
      //string.IsNullOrEmpty(scan.NetworkAdapter.NetworkName).Should().BeFalse();
      //string.IsNullOrEmpty(scan.NetworkAdapter.Ipv4).Should().BeFalse();
      //string.IsNullOrEmpty(scan.NetworkAdapter.MacAddress).Should().BeFalse();

      // Status should be up
      //Assert.Equal(OperationalStatus.Up, scan.NetworkAdapter.OperationalStatus);
      //scan.NetworkAdapter.OperationalStatus.Should().Be(OperationalStatus.Up);

      // ToDo: Why are we doing this?
      //scan.FindDevices();

      throw new NotImplementedException();
    }
  }
}
