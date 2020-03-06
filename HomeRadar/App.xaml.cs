// <copyright file="App.xaml.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar
{
    using System;
    using System.Threading.Tasks;
    using HomeRadar.Bootstrap;
    using HomeRadar.Contracts;
    using Xamarin.Forms;

    /// <summary>
    /// Xamarin Forms main App class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            try
            {
                this.InitializeComponent();
                this.InitializeApp();
                this.InitializeNavigation();
            }
            catch (TypeInitializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <inheritdoc/>
        protected override void OnStart()
        {
        }

        /// <inheritdoc/>
        protected override void OnSleep()
        {
        }

        /// <inheritdoc/>
        protected override void OnResume()
        {
        }

        /// <summary>
        /// The following method triggers app setup tasks such as dependency injection registration.
        /// </summary>
        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();
        }

        /// <summary>
        /// The following method triggers the initialisation of the Navigation Service.
        /// </summary>
        /// <returns>A Task.</returns>
        private async Task InitializeNavigation()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }
    }
}