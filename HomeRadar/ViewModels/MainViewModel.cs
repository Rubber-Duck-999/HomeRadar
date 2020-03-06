// <copyright file="MainViewModel.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels
{
    using System.Threading.Tasks;
    using HomeRadar.Contracts;
    using HomeRadar.ViewModels.Base;

    /// <summary>
    /// The following class defines the ViewModel for the Main page view.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private MenuViewModel menuViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">App navigation service.</param>
        /// <param name="menuViewModel">The MenuViewModel.</param>
        public MainViewModel(INavigationService navigationService, MenuViewModel menuViewModel)
          : base(navigationService)
        {
            this.menuViewModel = menuViewModel;
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
            await Task.WhenAll(
              this.menuViewModel.InitializeAsync(data),
              this.NavigationService.NavigateToAsync<PrimaryViewModel>());
        }
    }
}
