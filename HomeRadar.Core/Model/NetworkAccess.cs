// <copyright file="NetworkAccess.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
  /// <summary>
  /// Enum for network connection types.
  /// </summary>
  public enum NetworkAccess
  {
    /// <summary>
    /// Represents an unknown connection type.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Represents No connection type.
    /// </summary>
    None = 1,

    /// <summary>
    /// Represents a local connection type with no internet.
    /// </summary>
    Local = 2,

    /// <summary>
    /// Represents limited internet access.
    /// </summary>
    ConstrainedInternet = 3,

    /// <summary>
    /// Represents both internet and local network access.
    /// </summary>
    Internet = 4,
  }
}
