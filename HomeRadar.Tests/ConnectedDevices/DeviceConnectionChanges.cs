// <copyright file="UnitTest1.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Tests.ConnectedDevices
{
  using Xunit;

  /// <summary>
  /// Tests the ConnectivityStatusProvider provides an update when the devices connectivity changes.
  /// </summary>
  public class DeviceConnectionChanges
  {
    /// <summary>
    /// Tests when a devices connectivity changes from Internet to None the IsConnected property is updated
    /// from true to false and we receive the ChangeNotification.
    /// </summary>
    [Fact]
    public void DeviceChangesFromInternet_ToNone_ConfirmIsConnectedUpdated()
    {

    }
  }
}
