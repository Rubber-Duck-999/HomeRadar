// <copyright file="INavigationService.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Contracts
{
    using System;
    using System.Threading.Tasks;
    using HomeRadar.ViewModels.Base;

    /// <summary>
    /// The following defines the interface for Navigation within the app.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Initialises the application.
        /// </summary>
        /// <returns>No return.</returns>
        Task InitializeAsync();

        /// <summary>
        /// Triggers the navigation to a specified View via the corresponding ViewModel.
        /// </summary>
        /// <typeparam name="TViewModel">The ViewModel to reference.</typeparam>
        /// <returns>A Task.</returns>
        Task NavigateToAsync<TViewModel>()
            where TViewModel : ViewModelBase;

        /// <summary>
        /// Triggers the navigation to a specified View via the corresponding ViewModel with parameters.
        /// </summary>
        /// <typeparam name="TViewModel">The ViewModel to reference.</typeparam>
        /// <param name="parameter">ViewModel specific parameter.</param>
        /// <returns>A Task.</returns>
        Task NavigateToAsync<TViewModel>(object parameter)
            where TViewModel : ViewModelBase;

        /// <summary>
        /// Navigates to a specific view based on the provided ViewModel.
        /// </summary>
        /// <param name="viewModelType">The ViewModel of the View of interest.</param>
        /// <returns>A Task.</returns>
        Task NavigateToAsync(Type viewModelType);

        /// <summary>
        /// Clears the navigation stack to root.
        /// </summary>
        /// <returns>A Task.</returns>
        Task ClearBackStack();

        /// <summary>
        /// Navigates to a specific view based on the provided ViewModel.
        /// </summary>
        /// <param name="viewModelType">The ViewModel of the View of interest.</param>
        /// <param name="parameter">Any parameters required by the ViewModel.</param>
        /// <returns>A Task.</returns>
        Task NavigateToAsync(Type viewModelType, object parameter);

        /// <summary>
        /// Asynchronously removes the most recent Page off from the navigation stack.
        /// </summary>
        /// <returns>A Task.</returns>
        Task NavigateBackAsync();

        /// <summary>
        /// Removes the last page fron the navigation stack.
        /// </summary>
        /// <returns>A Task.</returns>
        Task RemoveLastFromBackStackAsync();

        /// <summary>
        /// Pops all but the root page off the navigation stack.
        /// </summary>
        /// <returns>A Task.</returns>
        Task PopToRootAsync();
    }
}