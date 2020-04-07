namespace HomeRadar.Tests.MockImplementations
{
  using System;
  using System.Collections.Generic;
  using Wrappers.Contracts;
  using Xamarin.Essentials;

  /// <summary>
  /// Mocks an IConnectivityWrapper implementation.
  /// </summary>
  public class MockConnectivityWrapper : IConnectivityWrapper
  {
    public MockConnectivityWrapper(NetworkAccess testAccess)
    {
      currentAccess = testAccess;
    }

    static event EventHandler<ConnectivityChangedEventArgs> ConnectivityChangedInternal;

    static NetworkAccess currentAccess;

    public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged
    {
      add
      {
        var wasRunning = ConnectivityChangedInternal != null;

        ConnectivityChangedInternal += value;
      }

      remove
      {
        var wasRunning = ConnectivityChangedInternal != null;

        ConnectivityChangedInternal -= value;
      }
    }

    public static void OnConnectivityChanged(NetworkAccess access, IEnumerable<ConnectionProfile> profiles)
      => OnConnectivityChanged(new ConnectivityChangedEventArgs(access, profiles));

    public static void OnConnectivityChanged(ConnectivityChangedEventArgs e)
    {
      if (currentAccess != e.NetworkAccess)
      {
        currentAccess = e.NetworkAccess;
        ConnectivityChangedInternal?.Invoke(null, e);
      }
    }

    public NetworkAccess TypeOfAccess()
    {
      return currentAccess;
    }
  }
}
