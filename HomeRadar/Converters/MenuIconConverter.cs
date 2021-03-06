﻿// <copyright file="MenuIconConverter.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Converters
{
  using System;
  using System.Globalization;
  using HomeRadar.Models;
  using Xamarin.Forms;

  /// <summary>
  /// Cross references a MenuItemType to it's icon.
  /// </summary>
  public class MenuIconConverter : IValueConverter
  {
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var type = (MenuItemType)value;

      switch (type)
      {
        case MenuItemType.Home:
          return "ic_home.png";
        default:
          return string.Empty;
      }
    }

    /// <inheritdoc />
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
