// <copyright file="UnitTest1.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Tests.ConnectedDevices
{
  using FluentAssertions;
  using HomeRadar.Tests.Helpers;
  using HomeRadar.Tests.MockImplementations;
  using Xamarin.Essentials;
  using Xunit;

  /// <summary>
  /// Tests the ConnectivityStatusProvider provides an update when the devices connectivity changes.
  /// </summary>
  public class DeviceConnectionChanges
  {
    /// <summary>
    /// Tests when a devices connectivity changes from Internet to None the IsConnected property is updated
    /// from true to false and as such we receive the ChangeNotification (because value has changed).
    /// </summary>
    [Fact]
    public void DeviceChangesFromInternet_ToNone_ConfirmIsConnectedUpdatedToFalse()
    {
      // Arrange
      var mockConnectivityWrapper = new MockConnectivityWrapper(NetworkAccess.Internet);
      var connectivityStatusProvider = Factory.GetConnectionStatusProvider(mockConnectivityWrapper);

      // Act
      connectivityStatusProvider.IsConnected.Should().BeTrue();
      MockConnectivityWrapper.OnConnectivityChanged(NetworkAccess.None, null);

      // Assert
      connectivityStatusProvider.IsConnected.Should().BeFalse();
    }

    /// <summary>
    /// Tests when a devices connectivity changes from Internet to Constrained the IsConnected property not modified.
    /// </summary>
    [Fact]
    public void DeviceChangesFromInternet_ToConstrained_ConfirmIsConnectedIsTrue()
    {
      // Arrange
      var mockConnectivityWrapper = new MockConnectivityWrapper(NetworkAccess.Internet);
      var connectivityStatusProvider = Factory.GetConnectionStatusProvider(mockConnectivityWrapper);

      // Act
      connectivityStatusProvider.IsConnected.Should().BeTrue();
      MockConnectivityWrapper.OnConnectivityChanged(NetworkAccess.ConstrainedInternet, null);

      // Assert
      connectivityStatusProvider.IsConnected.Should().BeTrue();
    }

    /// <summary>
    /// Tests when a devices connectivity changes from None to Internet the IsConnected property is updated
    /// from false to true and as such we receive the ChangeNotification (because value has changed).
    /// </summary>
    [Fact]
    public void DeviceChangesFromNone_ToInternet_ConfirmIsConnectedIsTrue()
    {
      // Arrange
      var mockConnectivityWrapper = new MockConnectivityWrapper(NetworkAccess.None);
      var connectivityStatusProvider = Factory.GetConnectionStatusProvider(mockConnectivityWrapper);

      // Act
      connectivityStatusProvider.IsConnected.Should().BeFalse();
      MockConnectivityWrapper.OnConnectivityChanged(NetworkAccess.Internet, null);

      // Assert
      connectivityStatusProvider.IsConnected.Should().BeTrue();
    }

    /// <summary>
    /// Tests when a devices connectivity changes from None to Internet the IsConnected property is updated
    /// from false to true and as such we receive the ChangeNotification (because value has changed).
    /// </summary>
    [Fact]
    public void DeviceChangesFromNone_ToLocal_ConfirmIsConnectedIsTrue()
    {
      // Arrange
      var mockConnectivityWrapper = new MockConnectivityWrapper(NetworkAccess.None);
      var connectivityStatusProvider = Factory.GetConnectionStatusProvider(mockConnectivityWrapper);

      // Act
      connectivityStatusProvider.IsConnected.Should().BeFalse();
      MockConnectivityWrapper.OnConnectivityChanged(NetworkAccess.Local, null);

      // Assert
      connectivityStatusProvider.IsConnected.Should().BeTrue();
    }
  }
}
