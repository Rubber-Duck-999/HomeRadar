// <copyright file="ArpUtil.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// The following class provides utility methods for the Arp class.
  /// </summary>
  public class ArpUtil
  {
    /// <summary>
    /// Processes a string collection to generate a MAC address.
    /// </summary>
    /// <param name="macAddresses">String collection.</param>
    /// <returns>MAC address.</returns>
    public static string GetMacAddress(IReadOnlyList<string> macAddresses)
    {
      if (macAddresses.Count >= 8)
      {
        return macAddresses[3].Substring(Math.Max(0, macAddresses[3].Length - 2))
               + "-" + macAddresses[4] + "-" + macAddresses[5] + "-" + macAddresses[6]
               + "-" + macAddresses[7] + "-"
               + macAddresses[8].Substring(0, 2);
      }

      return string.Empty;
    }
  }
}