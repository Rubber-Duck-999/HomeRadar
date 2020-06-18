// <copyright file="SettingsViewModel.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels
{
  using HomeRadar.Contracts;
  using HomeRadar.ViewModels.Base;

  /// <summary>
  /// The following class defines the ViewModel for the Scan view.
  /// </summary>
  public class SettingsViewModel : ViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">App navigation service.</param>
    public SettingsViewModel(INavigationService navigationService)
      : base(navigationService)
    {
    }
  }
}
