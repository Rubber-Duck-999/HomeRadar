// <copyright file="MainViewModel.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using HomeRadar.Contracts;
    using HomeRadar.ViewModels.Base;
    using Xamarin.Essentials;

    /// <summary>
    /// The following class defines the ViewModel for the Main page view.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private MenuViewModel menuViewModel;
        private readonly ILog logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">App navigation service.</param>
        /// <param name="menuViewModel">The MenuViewModel.</param>
        /// <param name="logger">The app logger.</param>
        public MainViewModel(
            INavigationService navigationService,
            MenuViewModel menuViewModel,
            ILog logger)
          : base(navigationService)
        {
            this.menuViewModel = menuViewModel;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets or sets the MenuViewModel.
        /// </summary>
        public MenuViewModel MenuViewModel
        {
            get => this.menuViewModel;
            set
            {
                this.menuViewModel = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initialise the ViewModel.
        /// </summary>
        /// <param name="data">Data required by ViewModel.</param>
        /// <returns>A task.</returns>
        public override async Task InitializeAsync(object data)
        {
            this.logger.Info(AppInfo.Name, $"Starting {nameof(PrimaryViewModel)}.");
            await Task.WhenAll(
              this.menuViewModel.InitializeAsync(data),
              this.NavigationService.NavigateToAsync<PrimaryViewModel>());
        }
    }
}
