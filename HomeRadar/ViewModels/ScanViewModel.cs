// <copyright file="ScanViewModel.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels
{
  using HomeRadar.Contracts;
    using HomeRadar.Core.Model;
    using HomeRadar.ViewModels.Base;

  /// <summary>
  /// The following class defines the ViewModel for the Scan view.
  /// </summary>
  public class ScanViewModel : ViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ScanViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">App navigation service.</param>
    public ScanViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      this.ShortTitle = "Scan";
      PortScanner new_port = new PortScanner();
            new_port.Run();
    }

    /// <summary>
    /// Gets the scan button text.
    /// </summary>
    public string ScanButtonText => "Scan";
  }
}
