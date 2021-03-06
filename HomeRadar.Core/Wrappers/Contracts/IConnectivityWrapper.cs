﻿// <copyright file="IConnectivityWrapper.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Wrappers.Contracts
{
  using HomeRadar.Core.Model;

  /// <summary>
  /// Defines the interface for wrapper 3rd party connectivity providers.
  /// </summary>
  public interface IConnectivityWrapper
  {
    /// <summary>
    /// Provides the type of access currently available.
    /// </summary>
    /// <returns>A NetworkAccess value.</returns>
    NetworkAccessType TypeOfAccess();
  }
}
