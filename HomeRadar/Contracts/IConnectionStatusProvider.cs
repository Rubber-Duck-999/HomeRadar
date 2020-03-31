// <copyright file="IConnectionStatusProvider.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Contracts
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  /// <summary>
  /// Defines the interface for confirming the device is connected to a network.
  /// </summary>
  public interface IConnectionStatusProvider
  {
    /// <summary>
    /// Gets a value indicating whether or not the device is connected to a network.
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// Checks if the device is currently connected to a network.
    /// </summary>
    void CheckConnection();
  }
}
