// <copyright file="DeviceIsConnected.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Tests.ConnectedDevices
{
  using FluentAssertions;
  using HomeRadar.Core.Model;
  using Xunit;

  /// <summary>
  /// Performs tests to confirm if a device is connected to a network.
  /// </summary>
  public class DeviceIsConnected
  {
    /// <summary>
    /// Tests if a device is connected to the Internet network the ConnectivityStatusProvider should return true for IsConnected.
    /// </summary>
    [Fact]
    public void DeviceIsConnectedToInternet_ShouldReturnTrueForConnectionStatusIsConnected()
    {
      // Arrange
      var connectivityStatusProvider = Helpers.Factory.GetConnectionStatusProvider(NetworkAccessType.Internet);

      // Act
      var isConnected = connectivityStatusProvider.IsConnected;

      // Assert
      isConnected.Should().BeTrue();
    }

    /// <summary>
    /// Tests if a device is connected to a Local network the ConnectivityStatusProvider should return true for IsConnected.
    /// </summary>
    [Fact]
    public void DeviceIsConnectedToLocal_ShouldReturnTrueForConnectionStatusIsConnected()
    {
      // Arrange
      var connectivityStatusProvider = Helpers.Factory.GetConnectionStatusProvider(NetworkAccessType.Local);

      // Act
      var isConnected = connectivityStatusProvider.IsConnected;

      // Assert
      isConnected.Should().BeTrue();
    }

    /// <summary>
    /// Tests if a device is connected to a ConstrainedInternet network the ConnectivityStatusProvider should return true for IsConnected.
    /// </summary>
    [Fact]
    public void DeviceIsConnectedToConstrainedInternet_ShouldReturnTrueForConnectionStatusIsConnected()
    {
      // Arrange
      var connectivityStatusProvider = Helpers.Factory.GetConnectionStatusProvider(NetworkAccessType.ConstrainedInternet);

      // Act
      var isConnected = connectivityStatusProvider.IsConnected;

      // Assert
      isConnected.Should().BeTrue();
    }

    /// <summary>
    /// Tests if a device is not connected to a network the ConnectivityStatusProvider should return false for IsConnected.
    /// </summary>
    [Fact]
    public void DeviceIsConnectedToNone_ShouldReturnFalseForConnectionStatusIsConnected()
    {
      // Arrange
      var connectivityStatusProvider = Helpers.Factory.GetConnectionStatusProvider(NetworkAccessType.None);

      // Act
      var isConnected = connectivityStatusProvider.IsConnected;

      // Assert
      isConnected.Should().BeFalse();
    }

    /// <summary>
    /// Tests if a device is not connected to a network the ConnectivityStatusProvider should return false for IsConnected.
    /// </summary>
    [Fact]
    public void DeviceIsConnectedToUnknown_ShouldReturnFalseForConnectionStatusIsConnected()
    {
      // Arrange
      var connectivityStatusProvider = Helpers.Factory.GetConnectionStatusProvider(NetworkAccessType.Unknown);

      // Act
      var isConnected = connectivityStatusProvider.IsConnected;

      // Assert
      isConnected.Should().BeFalse();
    }
  }
}
