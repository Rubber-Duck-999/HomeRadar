﻿// <copyright file="MockFactory.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Tests.Helpers
{
  using HomeRadar.Core.Model;
  using HomeRadar.Core.Wrappers.Contracts;
  using Moq;

  /// <summary>
  /// The following class acts as a factory for Mock objects creating using
  /// the MOQ framework.
  /// </summary>
  public class MockFactory
  {
    /// <summary>
    /// Creates an IConnectionStatusProvider moq object.
    /// Sets up the object to moq the in use 3rd party.
    /// </summary>
    /// <param name="networkAccess">Current network access.</param>
    /// <returns>An IConnectionStatusProvider moq object.</returns>
    public static Mock<IConnectivityWrapper> CreateConnectionStatusProvider(NetworkAccessType networkAccess)
    {
      var mockConnectionStatus = new Mock<IConnectivityWrapper>();
      mockConnectionStatus.Setup(c => c.TypeOfAccess()).Returns(networkAccess);

      return mockConnectionStatus;
    }
  }
}
