// <copyright file="MainMenuItem.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Models
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// The following class defines the functionality of an item found in the main menu.
    /// </summary>
    public class MainMenuItem : BindableObject
    {
        /// <summary>
        /// Holds the menu text value.
        /// </summary>
        private string menuText;

        /// <summary>
        /// Holds the menu item type enum.
        /// </summary>
        private MenuItemType menuItemType;

        /// <summary>
        /// Holds the type of the ViewModel to load.
        /// </summary>
        private Type viewModelToLoad;

        /// <summary>
        /// Gets or sets the menu text.
        /// </summary>
        public string MenuText
        {
            get => this.menuText;
            set
            {
                this.menuText = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Menu Item Type enum.
        /// </summary>
        public MenuItemType MenuItemType
        {
            get => this.menuItemType;
            set
            {
                this.menuItemType = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the ViewModel to load type.
        /// </summary>
        public Type ViewModelToLoad
        {
            get => this.viewModelToLoad;
            set
            {
                this.viewModelToLoad = value;
                this.OnPropertyChanged();
            }
        }
    }
}
