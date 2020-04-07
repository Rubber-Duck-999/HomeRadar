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
  using HomeRadar.Wrappers.Contracts;
  using Xamarin.Essentials;

  /// <summary>
  /// Implements the IConnectionStatusProvider to provide connection status information
  /// using Xamarin.Essentials.
  /// </summary>
  public class ConnectionStatusProvider : IConnectionStatusProvider, INotifyPropertyChanged
  {
    /// <summary>
    /// Provides access to the connectivity wrapper.
    /// </summary>
    private readonly IConnectivityWrapper connectivityWrapper;

    /// <summary>
    /// The following attribute stores whether or not the device is connected to a network.
    /// </summary>
    private bool isConnected;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionStatusProvider"/> class.
    /// </summary>
    /// <param name="connectivityWrapper">The apps connectivity wrapper.</param>
    public ConnectionStatusProvider(IConnectivityWrapper connectivityWrapper)
    {
      this.connectivityWrapper = connectivityWrapper;
      this.connectivityWrapper.ConnectivityChanged += this.ConnectivityWrapper_ConnectivityChanged;
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
        if (this.IsConnected != value)
        {
          this.isConnected = value;
          this.OnPropertyChanged(nameof(this.IsConnected));
        }
      }
    }

    /// <inheritdoc/>
    public void CheckConnection()
    {
      var connectivityType = this.connectivityWrapper.TypeOfAccess();
      this.UpdateConnectivity(connectivityType);
    }

    /// <summary>
    /// Forwards the notification to the app that a property has changed.
    /// </summary>
    /// <param name="propertyName">The name of the property that has changed.</param>
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Called when the device connectivity changes and checks the current connection.
    /// </summary>
    /// <param name="sender">Sending object.</param>
    /// <param name="e">Event arguments for ConnectivityChanged event.</param>
    // ToDo: Again we have a coupling with Xamarin.Essentials here. I would suggest we should be using this but we could also
    // add a layer of abstraction if we want to do so.
    private void ConnectivityWrapper_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
      this.CheckConnection();
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
  }
}
