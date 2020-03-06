// <copyright file="MenuViewModel.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels
{
    using System.Collections.ObjectModel;
    using HomeRadar.Contracts;
    using HomeRadar.Models;
    using HomeRadar.ViewModels.Base;

    /// <summary>
    /// The following class defines the ViewModel for the menu view.
    /// </summary>
    public class MenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Container for the menu items.
        /// </summary>
        private ObservableCollection<MainMenuItem> menuItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The application NavigationService.</param>
        public MenuViewModel(INavigationService navigationService)
          : base(navigationService)
        {
            this.MenuItems = new ObservableCollection<MainMenuItem>();
            this.LoadMenuItems();
        }

        /// <summary>
        /// Gets the Menu welcome text.
        /// </summary>
        public string WelcomeText => "Welcome to Home Radar.";

        /// <summary>
        /// Gets or sets the menu items.
        /// </summary>
        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => this.menuItems;
            set
            {
                this.menuItems = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Fills teh menu item container with required menu items.
        /// ToDo: Look at making this configurable.
        /// </summary>
        private void LoadMenuItems()
        {
            this.MenuItems.Add(new MainMenuItem
            {
                MenuText = "Home Radar",
                ViewModelToLoad = typeof(PrimaryViewModel),
                MenuItemType = MenuItemType.HomeRadar,
            });
        }
    }
}
