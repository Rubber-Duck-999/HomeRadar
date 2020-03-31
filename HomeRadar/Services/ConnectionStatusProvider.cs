// <copyright file="ConnectionStatusProvider.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Services
{
  using System;
  using System.ComponentModel;
  using System.Runtime.CompilerServices;
  using Annotations;
  using HomeRadar.Contracts;
  using Wrappers;
  using Xamarin.Essentials;

  /// <summary>
  /// Implements the IConnectionStatusProvider to provide connection status information
  /// using Xamarin.Essentials.
  /// </summary>
  public class ConnectionStatusProvider : IConnectionStatusProvider, INotifyPropertyChanged
  {
    /// <summary>
    /// The following attribute stores whether or not the device is connected to a network.
    /// </summary>
    private bool isConnected;

    /// <summary>
    /// Provides access to the connectivity wrapper.
    /// </summary>
    private IConnectivityWrapper connectivityWrapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionStatusProvider"/> class.
    /// </summary>
    /// <param name="connectivityWrapper">The apps connectivity wrapper.</param>
    public ConnectionStatusProvider(IConnectivityWrapper connectivityWrapper)
    {
      this.connectivityWrapper = connectivityWrapper;
      this.CheckConnection();
    }

    /// <inheritdoc/>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <inheritdoc/>
    public bool IsConnected
    {
      get => this.isConnected;
      set
      {
        this.isConnected = value;
        this.OnPropertyChanged(nameof(this.IsConnected));
      }
    }

    /// <inheritdoc/>
    public void CheckConnection()
    {
      var connectivityType = this.connectivityWrapper.TypeOfAccess();
      this.UpdateConnectivity(connectivityType);
    }

    /// <summary>
    /// Updates the apps connectivity based on NetworkAccess.
    /// </summary>
    /// <param name="connectivityType">Current connectivity type.</param>
    /// <exception cref="ArgumentOutOfRangeException">Argument is not valid.</exception>
    private void UpdateConnectivity(NetworkAccess connectivityType)
    {
      switch (connectivityType)
      {
        case NetworkAccess.Unknown:
        case NetworkAccess.None:
          this.IsConnected = false;
          break;
        case NetworkAccess.Local:
        case NetworkAccess.Internet:
        case NetworkAccess.ConstrainedInternet:
          this.IsConnected = true;
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(connectivityType), connectivityType, null);
      }
    }


    /// <summary>
    /// Forwards the notification to the app that a property has changed.
    /// </summary>
    /// <param name="propertyName">The name of the property that has changed.</param>
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
