// <copyright file="BindableBehaviour.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Behaviours
{
  using System;
  using Xamarin.Forms;

  /// <summary>
  /// The following class defines the base behaviour for all custom behaviours.
  /// </summary>
  /// <typeparam name="T">The type to assign behaviour to.</typeparam>
  public class BindableBehaviour<T> : Behavior<T>
      where T : BindableObject
  {
    /// <summary>
    /// Gets the associated object.
    /// </summary>
    public T AssociatedObject { get; private set; }

    /// <inheritdoc/>
    protected override void OnAttachedTo(T visualElement)
    {
      base.OnAttachedTo(visualElement);

      this.AssociatedObject = visualElement;

      if (visualElement.BindingContext != null)
      {
        this.BindingContext = visualElement.BindingContext;
      }

      visualElement.BindingContextChanged += this.OnBindingContextChanged;
    }

    /// <inheritdoc/>
    protected override void OnDetachingFrom(T view)
    {
      view.BindingContextChanged -= this.OnBindingContextChanged;
    }

    /// <inheritdoc/>
    protected override void OnBindingContextChanged()
    {
      base.OnBindingContextChanged();
      this.BindingContext = this.AssociatedObject.BindingContext;
    }

    /// <summary>
    /// Raises change on BindingContext.
    /// </summary>
    /// <param name="sender">Object triggering the change.</param>
    /// <param name="e">Any event arguements.</param>
    private void OnBindingContextChanged(object sender, EventArgs e)
    {
      this.OnBindingContextChanged();
    }
  }
}
