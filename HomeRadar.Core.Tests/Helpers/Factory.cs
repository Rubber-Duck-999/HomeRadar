// <copyright file="Factory.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Tests.Helpers
{
  using HomeRadar.Core.Model;
  using HomeRadar.Core.Services;

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
    public static ConnectionStatusProvider GetConnectionStatusProvider(NetworkAccessType networkAccess)
    {
      // Create mock connectivity wrapper, we are not testing 3rd party code so we can mock it out.
      var connectivityWrapper = Helpers.MockFactory.CreateConnectionStatusProvider(networkAccess);

      // Create connectivity provider passing our mock connectivity wrapper
      var connectionStatusProvider = new ConnectionStatusProvider(connectivityWrapper.Object);

      return connectionStatusProvider;
    }
  }
}
