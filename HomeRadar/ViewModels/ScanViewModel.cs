// <copyright file="ScanViewModel.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels
{
  using System;
  using System.Windows.Input;
  using HomeRadar.Contracts;
  using HomeRadar.ViewModels.Base;
  using Xamarin.Forms;

  /// <summary>
  /// The following class defines the ViewModel for the Scan view.
  /// </summary>
  public class ScanViewModel : ViewModelBase
  {
    /// <summary>
    /// Determines whether the scan functionality is enabled.
    /// </summary>
    private bool isScanEnabled;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScanViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">App navigation service.</param>
    public ScanViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      this.ShortTitle = "Scan";
      this.IsScanEnabled = false;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the scan functionality is enabled.
    /// </summary>
    public bool IsScanEnabled
    {
      get => this.isScanEnabled;
      set
      {
        if (this.isScanEnabled != value)
        {
          this.isScanEnabled = value;
          this.OnPropertyChanged(nameof(this.IsScanEnabled));
        }
      }
    }

    /// <summary>
    /// Gets the scan button text.
    /// </summary>
    public string ScanButtonText => "Scan";

    /// <summary>
    /// Gets the command to be executed when a scan is triggered.
    /// </summary>
    public ICommand ScanCommand => new Command(this.OnScanTapped);

    /// <summary>
    /// Performs a scan.
    /// </summary>
    private async void OnScanTapped()
    {
      // ToDo: Call backend code that will perform a scan.
      // The object to do this will need to be injected in through the constructor and kept as a private member variable.
      // It will also need to be hooked up with the Dependency Injection container in AppContainer.
      // Once complete where are you expecting this information to be stored?
      // Should the current view update to show the results or are we having a separate View that will hold the results of scans?
      throw new NotImplementedException();
    }
  }
}
