// <copyright file="NavigationService.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Services
{
  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using HomeRadar.Bootstrap;
  using HomeRadar.Contracts;
  using HomeRadar.ViewModels;
  using HomeRadar.ViewModels.Base;
  using HomeRadar.Views;
  using Xamarin.Forms;

  /// <summary>
  /// The following class handles the navigation for the application.
  /// </summary>
  public class NavigationService : INavigationService
  {
    /// <summary>
    /// Holds the View to ViewModel mappings.
    /// </summary>
    private readonly Dictionary<Type, Type> mappings;

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationService"/> class.
    /// </summary>
    public NavigationService()
    {
      this.mappings = new Dictionary<Type, Type>();
      this.CreatePageViewModelMappings();
    }

    /// <summary>
    /// Gets a reference to the current application.
    /// </summary>
    protected Application CurrentApplication => Application.Current;

    /// <inheritdoc/>
    public async Task ClearBackStack()
    {
      await this.CurrentApplication.MainPage.Navigation.PopToRootAsync();
    }

    /// <inheritdoc/>
    public async Task InitializeAsync()
    {
      await this.NavigateToAsync<MainViewModel>();
    }

    /// <inheritdoc/>
    public async Task NavigateBackAsync()
    {
      if (this.CurrentApplication.MainPage is MainView mainPage)
      {
        await mainPage.Navigation.PopAsync();
      }
      else if (this.CurrentApplication.MainPage != null)
      {
        await this.CurrentApplication.MainPage.Navigation.PopAsync();
      }
    }

    /// <inheritdoc/>
    public Task NavigateToAsync<TViewModel>()
      where TViewModel : ViewModelBase
    {
      return this.InternalNavigateToAsync(typeof(TViewModel));
    }

    /// <inheritdoc/>
    public Task NavigateToAsync<TViewModel>(object parameter)
      where TViewModel : ViewModelBase
    {
      return this.InternalNavigateToAsync(typeof(TViewModel), parameter);
    }

    /// <inheritdoc/>
    public Task NavigateToAsync(Type viewModelType)
    {
      return this.InternalNavigateToAsync(viewModelType);
    }

    /// <inheritdoc/>
    public Task NavigateToAsync(Type viewModelType, object parameter)
    {
      return this.InternalNavigateToAsync(viewModelType, parameter);
    }

    /// <inheritdoc/>
    public async Task PopToRootAsync()
    {
      if (this.CurrentApplication.MainPage is MainView mainPage)
      {
        await mainPage.Navigation.PopToRootAsync();
      }
    }

    /// <inheritdoc/>
    public Task RemoveLastFromBackStackAsync()
    {
      if (this.CurrentApplication.MainPage is MainView mainPage)
      {
        mainPage.Navigation.RemovePage(
          mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
      }

      return Task.FromResult(true);
    }

    /// <summary>
    /// Checks the Mappings collection for a View matching the ViewModel.
    /// </summary>
    /// <param name="viewModelType">The ViewModel to check.</param>
    /// <returns>The View type.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when viewModelType not found.</exception>
    protected Type GetPageTypeFromViewModel(Type viewModelType)
    {
      if (!this.mappings.ContainsKey(viewModelType))
      {
        throw new KeyNotFoundException("No map for ${viewModelType} was found on navigation mappings");
      }

      return this.mappings[viewModelType];
    }

    /// <summary>
    /// The following method creates a page associated with a ViewModel and binds the
    /// ViewModel to the page.
    /// </summary>
    /// <param name="viewModelType">The ViewModel to associate and bind.</param>
    /// <param name="parameter">Any parameters required by the ViewModel.</param>
    /// <returns>A Page.</returns>
    /// <exception cref="Exception">Thrown when a viewModelType is not a page.</exception>
    protected Page CreateAndBindPage(Type viewModelType, object parameter = null)
    {
      Type pageType = this.GetPageTypeFromViewModel(viewModelType);

      if (pageType == null)
      {
        throw new Exception($"Mapping type for {viewModelType} is not a page.");
      }

      Page page = Activator.CreateInstance(pageType) as Page;
      ViewModelBase viewModel = AppContainer.Resolve(viewModelType) as ViewModelBase;
      page.BindingContext = viewModel;

      return page;
    }

    /// <summary>
    /// Creates a page associated with the ViewModel and pushes it on the navigation stack.
    /// </summary>
    /// <param name="viewModelType">The ViewModel to associate and bind.</param>
    /// <param name="parameter">Any parameters required by the ViewModel.</param>
    /// <returns>A Task.</returns>
    private async Task InternalNavigateToAsync(Type viewModelType, object parameter = null)
    {
      Page page = null;

      try
      {
        page = this.CreateAndBindPage(viewModelType, parameter);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }

      if (page is MainView)
      {
        this.CurrentApplication.MainPage = page;
      }
      else if (this.CurrentApplication.MainPage is MainView)
      {
        var mainPage = this.CurrentApplication.MainPage as MainView;

        if (mainPage.Detail is DefaultNavigationPage navigationPage)
        {
          var currentPage = navigationPage.CurrentPage;

          if (currentPage.GetType() != page.GetType())
          {
            await navigationPage.PushAsync(page);
          }
        }
        else
        {
          navigationPage = new DefaultNavigationPage(page);
          mainPage.Detail = navigationPage;
        }

        mainPage.IsPresented = false;
      }
      else
      {
        var navigationPage = this.CurrentApplication.MainPage as DefaultNavigationPage;

        if (navigationPage != null)
        {
          await navigationPage.PushAsync(page);
        }
        else
        {
          this.CurrentApplication.MainPage = new DefaultNavigationPage(page);
        }
      }

      await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
    }

    /// <summary>
    /// Creates the mapping between Views and ViewModels.
    /// </summary>
    private void CreatePageViewModelMappings()
    {
      this.mappings.Add(typeof(MainViewModel), typeof(MainView));
      this.mappings.Add(typeof(MenuViewModel), typeof(MenuView));
      this.mappings.Add(typeof(PrimaryViewModel), typeof(PrimaryView));
      this.mappings.Add(typeof(ScanViewModel), typeof(ScanView));
      this.mappings.Add(typeof(SettingsViewModel), typeof(SettingsView));
    }
  }
}