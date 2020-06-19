// <copyright file="AppContainer.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Bootstrap
{
  using System;
  using Autofac;
  using HomeRadar.Contracts;
  using HomeRadar.Services;
  using HomeRadar.ViewModels;

  /// <summary>
  /// The following class registers and resolves dependencies.
  /// </summary>
  public class AppContainer
  {
    /// <summary>
    /// Container for all the dependencies.
    /// </summary>
    private static IContainer container;

    /// <summary>
    /// The following method registers all the dependencies the app requires.
    /// </summary>
    public static void RegisterDependencies()
    {
      var builder = new ContainerBuilder();

      // Services
      builder.RegisterType<NavigationService>().As<INavigationService>();

      // ViewModels
      builder.RegisterType<MainViewModel>();
      builder.RegisterType<MenuViewModel>();
      builder.RegisterType<PrimaryViewModel>();
      builder.RegisterType<ScanViewModel>();

      // Build
      container = builder.Build();
    }

    /// <summary>
    /// The following method resolves a dependency.
    /// </summary>
    /// <param name="typeName">The type of interest.</param>
    /// <returns>The required dependency.</returns>
    public static object Resolve(Type typeName)
    {
      return container.Resolve(typeName);
    }

    /// <summary>
    /// The following method resolves a dependency.
    /// </summary>
    /// <typeparam name="T">The type of interest.</typeparam>
    /// <returns>The required dependency.</returns>
    public static T Resolve<T>()
    {
      return container.Resolve<T>();
    }
  }
}
