// <copyright file="EssentialsConnectivityWrapper.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Wrappers
{
  using HomeRadar.Wrappers.Contracts;
  using Xamarin.Essentials;

  /// <summary>
  /// Implements the IConnectivityWrapper interface using Xamarin.Essentials.
  /// </summary>
  public class EssentialsConnectivityWrapper : IConnectivityWrapper
  {
    /// <inheritdoc/>
    public NetworkAccess TypeOfAccess()
    {
      // ToDo: Consider making our own NetworkAccess enum then we can map the 3rd party to ours.
      // For now we can use Xamarin.Essentials NetworkAccess as it does what we need.
      return Connectivity.NetworkAccess;
    }
  }
}
