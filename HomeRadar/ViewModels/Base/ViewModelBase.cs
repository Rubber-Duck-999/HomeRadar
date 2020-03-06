// <copyright file="ViewModelBase.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.ViewModels.Base
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Bookamare.Mobile.Annotations;
    using HomeRadar.Contracts;

    /// <summary>
    /// The following class defines the state and behaviour present in all ViewModels.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// The following attribute stops multiple processing attempts.
        /// </summary>
        private bool isBusy = false;

        /// <summary>
        /// The following attribute holds the title of the ViewModel.
        /// </summary>
        private string title = string.Empty;

        /// <summary>
        /// The following attribute holds the short title of the ViewModel for the menu.
        /// </summary>
        private string shortTitle = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        /// <param name="navigationService">The application NavigationService.</param>
        public ViewModelBase(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the ViewModel is busy.
        /// </summary>
        public bool IsBusy
        {
            get => this.isBusy;
            set
            {
                this.isBusy = value;
                this.OnPropertyChanged(nameof(this.IsBusy));
            }
        }

        /// <summary>
        /// Gets or sets the title of the ViewModel.
        /// </summary>
        public string Title
        {
            get => this.title;
            set
            {
                this.title = value;
                this.OnPropertyChanged(nameof(this.Title));
            }
        }

        /// <summary>
        /// Gets or sets the short title of the ViewModel.
        /// </summary>
        public string ShortTitle
        {
            get => this.shortTitle;
            set
            {
                this.shortTitle = value;
                this.OnPropertyChanged(nameof(this.shortTitle));
            }
        }

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        public INavigationService NavigationService { get; }

        /// <summary>
        /// The following method initializes the ViewModel.
        /// </summary>
        /// <param name="data">Data required to initialize class.</param>
        /// <returns>A Task.</returns>
        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }

        /// <summary>
        /// Forwards the notification to the app that a property has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}