// <copyright file="ConnectionStatusProvider.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Services
{
  using System;
  using HomeRadar.Core.Contracts;
  using HomeRadar.Core.Model;
  using HomeRadar.Core.Wrappers.Contracts;

  /// <summary>
  /// Implements the IConnectionStatusProvider to provide connection status information
  /// using Xamarin.Essentials.
  /// </summary>
  public class ConnectionStatusProvider : IConnectionStatusProvider
  {
    /// <summary>
    /// Provides access to the connectivity wrapper.
    /// </summary>
    private readonly IConnectivityWrapper connectivityWrapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionStatusProvider"/> class.
    /// </summary>
    /// <param name="connectivityWrapper">The apps connectivity wrapper.</param>
    public ConnectionStatusProvider(IConnectivityWrapper connectivityWrapper)
    {
      this.connectivityWrapper = connectivityWrapper;
      this.CheckConnection();
    }

    /// <inheritdoc/>
    public bool IsConnected { get; set; }

    /// <inheritdoc/>
    public void CheckConnection()
    {
      var connectivityType = this.connectivityWrapper.TypeOfAccess();
      this.UpdateConnectivity(connectivityType);
    }

    /// <summary>
    /// Updates the apps connectivity based on NetworkAccess.
    /// </summary>
    /// <param name="connectivityType">Current connectivity type.</param>
    /// <exception cref="ArgumentOutOfRangeException">Argument is not valid.</exception>
    private void UpdateConnectivity(NetworkAccessType connectivityType)
    {
      switch (connectivityType)
      {
        case NetworkAccessType.Unknown:
        case NetworkAccessType.None:
          this.IsConnected = false;
          break;
        case NetworkAccessType.Local:
        case NetworkAccessType.Internet:
        case NetworkAccessType.ConstrainedInternet:
          this.IsConnected = true;
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(connectivityType), connectivityType, null);
      }
    }
  }
}
