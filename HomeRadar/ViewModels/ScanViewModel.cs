// <copyright file="ScanViewModel.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels
{
  using System;
  using System.Windows.Input;
  using HomeRadar.Contracts;
  using HomeRadar.Enums;
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
    /// Determine which scan type to use.
    /// </summary>
    private ScanTypes scanType = ScanTypes.None;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScanViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">App navigation service.</param>
    public ScanViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      this.ShortTitle = "Scan";
      this.DisableScan();
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
    /// Gets the command to be executed when a scan is triggered.
    /// </summary>
    public ICommand AllScanCommand => new Command(this.AllScanTapped);

    /// <summary>
    /// Gets the command to be executed when a scan is triggered.
    /// </summary>
    public ICommand DevicesOnlyScanCommand => new Command(this.DevicesOnlyScanTapped);

    /// <summary>
    /// Gets the command to be executed when a scan is triggered.
    /// </summary>
    public ICommand IntrusiveScanCommand => new Command(this.IntrusiveScanTapped);

    /// <summary>
    /// Gets the command to be executed when a scan is triggered.
    /// </summary>
    public ICommand IntensiveScanCommand => new Command(this.IntensiveScanTapped);

    /// <summary>
    /// Performs a scan.
    /// ToDo: This will need to be async.
    /// </summary>
    private void OnScanTapped()
    {
      // ToDo: Call backend code that will perform a scan.
      // The object to do this will need to be injected in through the constructor and kept as a private member variable.
      // It will also need to be hooked up with the Dependency Injection container in AppContainer.
      // Once complete where are you expecting this information to be stored?
      // Should the current view update to show the results or are we having a separate View that will hold the results of scans?
      switch (this.scanType)
      {
        case ScanTypes.All:
          // Perform All scan.
          break;
        case ScanTypes.DevicesOnly:
          // Perform DevicesOnly scan.
          break;
        case ScanTypes.Intensive:
          // Perform Intensive scan.
          break;
        case ScanTypes.Intrusive:
          // Perform Intrusive scan.
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      throw new NotImplementedException();
    }

    /// <summary>
    /// Sets scan type to All scan.
    /// </summary>
    private void AllScanTapped()
    {
      this.scanType = ScanTypes.All;
      this.EnableScan();
    }

    /// <summary>
    /// Sets scan type to DevicesOnly scan.
    /// </summary>
    private void DevicesOnlyScanTapped(object obj)
    {
      this.scanType = ScanTypes.DevicesOnly;
      this.EnableScan();
    }

    /// <summary>
    /// Sets scan type to Intensive scan.
    /// </summary>
    private void IntensiveScanTapped(object obj)
    {
      this.scanType = ScanTypes.Intensive;
      this.EnableScan();
    }

    /// <summary>
    /// Sets scan type to Intrusive scan.
    /// </summary>
    private void IntrusiveScanTapped(object obj)
    {
      this.scanType = ScanTypes.Intrusive;
      this.EnableScan();
    }

    /// <summary>
    /// Enabled the scan button.
    /// </summary>
    private void EnableScan()
    {
      this.IsScanEnabled = true;
    }

    /// <summary>
    /// Disables the scan button.
    /// </summary>
    private void DisableScan()
    {
      this.IsScanEnabled = false;
    }
  }
}
