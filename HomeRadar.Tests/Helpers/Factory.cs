// <copyright file="Factory.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Tests.Helpers
{
  using HomeRadar.Services;
  using Xamarin.Essentials;

  /// <summary>
  /// The following class creates objects to test.
  /// </summary>
  public class Factory
  {
    /// <summary>
    /// Creates a ConnectionStatusProvider with a mock ConnectivityWrapper.
    /// </summary>
    /// <param name="networkAccess">Current Network Access.</param>
    /// <returns>A ConnectionStatusProvider.</returns>
    public static ConnectionStatusProvider GetConnectionStatusProvider(NetworkAccess networkAccess)
    {
      // Create mock connectivity wrapper, we are not testing 3rd party code so we can mock it out.
      var connectivityWrapper = Helpers.MockFactory.CreateMockConnectivityWrapper(networkAccess);

      // Create connectivity provider passing our mock connectivity wrapper
      var connectionStatusProvider = new ConnectionStatusProvider(connectivityWrapper.Object);

      return connectionStatusProvider;
    }
  }
}
