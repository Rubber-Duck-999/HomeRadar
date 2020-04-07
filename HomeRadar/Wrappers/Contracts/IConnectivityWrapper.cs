// <copyright file="IConnectivityWrapper.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Wrappers.Contracts
{
  using System;
  using Xamarin.Essentials;

  /// <summary>
  /// Defines the interface for wrapper 3rd party connectivity providers.
  /// </summary>
  public interface IConnectivityWrapper
  {
    /// <summary>
    /// Handles the registration for ConnectivityChanged events.
    /// </summary>
    event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;

    /// <summary>
    /// Provides the type of access currently available.
    /// </summary>
    /// <returns>A NetworkAccess value.</returns>
    NetworkAccess TypeOfAccess();
  }
}
