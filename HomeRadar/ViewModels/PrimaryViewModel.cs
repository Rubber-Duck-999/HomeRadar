// <copyright file="HomeRadarViewModel.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels
{
    using HomeRadar.Contracts;
    using HomeRadar.ViewModels.Base;

    /// <summary>
    /// The following class defines the ViewModel for providing
    /// the information about ---- place statement here ----.
    /// </summary>
    public class PrimaryViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The App NavigationService.</param>
        public PrimaryViewModel(INavigationService navigationService)
          : base(navigationService)
        {
            this.ShortTitle = "Home Radar";
        }
    }
}
