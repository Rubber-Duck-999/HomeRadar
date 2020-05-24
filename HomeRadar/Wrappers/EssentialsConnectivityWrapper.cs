// <copyright file="EssentialsConnectivityWrapper.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Wrappers
{
  using HomeRadar.Core.Model;
  using HomeRadar.Core.Wrappers.Contracts;
  using Xamarin.Essentials;

  /// <summary>
  /// Implements the IConnectivityWrapper interface using Xamarin.Essentials.
  /// </summary>
  public class EssentialsConnectivityWrapper : IConnectivityWrapper
  {
    /// <inheritdoc/>
    public NetworkAccessType TypeOfAccess()
    {
      switch (Connectivity.NetworkAccess)
      {
        case NetworkAccess.None:
          return NetworkAccessType.None;
        case NetworkAccess.Local:
          return NetworkAccessType.Local;
        case NetworkAccess.ConstrainedInternet:
          return NetworkAccessType.ConstrainedInternet;
        case NetworkAccess.Internet:
          return NetworkAccessType.Internet;
        case NetworkAccess.Unknown:
        default:
          return NetworkAccessType.Unknown;
      }
    }
  }
}
