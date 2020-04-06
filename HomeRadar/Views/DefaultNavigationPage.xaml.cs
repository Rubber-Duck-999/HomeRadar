// <copyright file="DefaultNavigationPage.xaml.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Views
{
  using Xamarin.Forms;
  using Xamarin.Forms.Xaml;

  /// <summary>
  /// The following class defines the root of all content pages.
  /// </summary>
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class DefaultNavigationPage : NavigationPage
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultNavigationPage"/> class.
    /// </summary>
    public DefaultNavigationPage() => this.InitializeComponent();

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultNavigationPage"/> class.
    /// </summary>
    /// <param name="root">Page to include.</param>
    public DefaultNavigationPage(Page root)
      : base(root) => this.InitializeComponent();
  }
}