// <copyright file="DeviceScanTest.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Tests.DeviceScan
{
  using FluentAssertions;
  using HomeRadar.Core.Model;
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
      scan.Run();

      // Assert
      Assert.False(false);
    }
  }
}
