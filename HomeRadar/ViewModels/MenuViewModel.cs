// <copyright file="MenuViewModel.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels
{
  using System.Collections.ObjectModel;
  using System.Windows.Input;
  using HomeRadar.Contracts;
  using HomeRadar.Models;
  using HomeRadar.ViewModels.Base;
  using Xamarin.Forms;

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
    /// Gets the command the view binds to.
    /// </summary>
    public ICommand MenuItemTappedCommand => new Command(this.OnMenuItemTapped);

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
        MenuItemType = MenuItemType.Home,
      });
    }

    /// <summary>
    /// Provides navigation based on menu item pressed.
    /// </summary>
    /// <param name="menuItemTappedEventArgs">The menu item event args.</param>
    private void OnMenuItemTapped(object menuItemTappedEventArgs)
    {
      var menuItem = (menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem;

      if (menuItem != null)
      {
        this.NavigationService.ClearBackStack();
      }

      var type = menuItem?.ViewModelToLoad;
      this.NavigationService.NavigateToAsync(type);
    }
  }
}
