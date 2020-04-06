// <copyright file="EventToCommandBehaviour.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>
#pragma warning disable SA1401

namespace HomeRadar.Behaviours
{
  using System;
  using System.Globalization;
  using System.Linq;
  using System.Linq.Expressions;
  using System.Reflection;
  using System.Windows.Input;
  using Xamarin.Forms;

  /// <summary>
  /// The following class transitions an event to a behaviour.
  /// </summary>
  public class EventToCommandBehaviour : BindableBehaviour<View>
  {
    /// <summary>
    /// Holds the Name of the event.
    /// </summary>
    public static BindableProperty EventNameProperty =
        BindableProperty.CreateAttached(
          "EventName",
          typeof(string),
          typeof(EventToCommandBehaviour),
          null);

    /// <summary>
    /// Stores the command to be triggered.
    /// </summary>
    public static BindableProperty CommandProperty =
        BindableProperty.CreateAttached(
          "Command",
          typeof(ICommand),
          typeof(EventToCommandBehaviour),
          null);

    /// <summary>
    /// Holds any parameters required as part of the event.
    /// </summary>
    public static BindableProperty CommandParameterProperty =
        BindableProperty.CreateAttached(
          "CommandParameter",
          typeof(object),
          typeof(EventToCommandBehaviour),
          null);

    /// <summary>
    /// Holds the Converter for the event arguments.
    /// </summary>
    public static BindableProperty EventArgsConverterProperty =
        BindableProperty.CreateAttached(
          "EventArgsConverter",
          typeof(IValueConverter),
          typeof(EventToCommandBehaviour),
          null);

    /// <summary>
    /// Holds the Converter for the event argument parameters.
    /// </summary>
    public static BindableProperty EventArgsConverterParameterProperty =
        BindableProperty.CreateAttached(
          "EventArgsConverterParameter",
          typeof(object),
          typeof(EventToCommandBehaviour),
          null);

    /// <summary>
    /// The delegate for events to trigger on.
    /// </summary>
    protected Delegate handler;

    /// <summary>
    /// Provides the information of an event.
    /// </summary>
    private EventInfo eventInfo;

    /// <summary>
    /// Gets or sets the name of the event.
    /// </summary>
    public string EventName
    {
      get => (string)this.GetValue(EventNameProperty);
      set => this.SetValue(EventNameProperty, value);
    }

    /// <summary>
    /// Gets or sets the command to trigger.
    /// </summary>
    public ICommand Command
    {
      get => (ICommand)this.GetValue(CommandProperty);
      set => this.SetValue(CommandProperty, value);
    }

    /// <summary>
    /// Gets or sets the parameter for the command.
    /// </summary>
    public object CommandParameter
    {
      get => this.GetValue(CommandParameterProperty);
      set => this.SetValue(CommandParameterProperty, value);
    }

    /// <summary>
    /// Gets or sets the converter for the event arguments.
    /// </summary>
    public IValueConverter EventArgsConverter
    {
      get => (IValueConverter)this.GetValue(EventArgsConverterProperty);
      set => this.SetValue(EventArgsConverterProperty, value);
    }

    /// <summary>
    /// Gets or sets the converter for any parameters.
    /// </summary>
    public object EventArgsConverterParameter
    {
      get => this.GetValue(EventArgsConverterParameterProperty);
      set => this.SetValue(EventArgsConverterParameterProperty, value);
    }

    /// <summary>
    /// Associates a view with an event handler.
    /// </summary>
    /// <param name="view">The view to associate.</param>
    protected override void OnAttachedTo(View view)
    {
      base.OnAttachedTo(view);

      var events = this.AssociatedObject.GetType().GetRuntimeEvents().ToArray();
      if (!events.Any())
      {
        return;
      }

      this.eventInfo = events.FirstOrDefault(e => e.Name == this.EventName);
      if (this.eventInfo == null)
      {
        throw new ArgumentException(
            $"EventToCommand: Can't find any event named '{this.EventName}' on attached type");
      }

      this.AddEventHandler(this.eventInfo, this.AssociatedObject, this.OnFired);
    }

    /// <summary>
    /// Disassociates a view with an event handler.
    /// </summary>
    /// <param name="view">The view to disassociate.</param>
    protected override void OnDetachingFrom(View view)
    {
      if (this.handler != null)
      {
        this.eventInfo.RemoveEventHandler(this.AssociatedObject, this.handler);
      }

      base.OnDetachingFrom(view);
    }

    /// <summary>
    /// Adds an event handler delegate to an event.
    /// </summary>
    /// <param name="eventInfoParam">Details of the event to add handler.</param>
    /// <param name="item">The object to attach handler to. </param>
    /// <param name="action">Method to trigger on event.</param>
    private void AddEventHandler(EventInfo eventInfoParam, object item, Action<object, EventArgs> action)
    {
      var eventParameters = eventInfoParam.EventHandlerType
          .GetRuntimeMethods().First(m => m.Name == "Invoke")
          .GetParameters()
          .Select(p => Expression.Parameter(p.ParameterType))
          .ToArray();

      var actionInvoke = action.GetType()
          .GetRuntimeMethods().First(m => m.Name == "Invoke");

      this.handler = Expression.Lambda(
          eventInfoParam.EventHandlerType,
          Expression.Call(Expression.Constant(action), actionInvoke, eventParameters[0], eventParameters[1]),
          eventParameters)
        .Compile();

      eventInfoParam.AddEventHandler(item, this.handler);
    }

    /// <summary>
    /// Triggers the command when an event is fired.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="eventArgs">Any arguments required as part of the event.</param>
    private void OnFired(object sender, EventArgs eventArgs)
    {
      if (this.Command == null)
      {
        return;
      }

      var parameter = this.CommandParameter;

      if (eventArgs != null && eventArgs != EventArgs.Empty)
      {
        parameter = eventArgs;

        if (this.EventArgsConverter != null)
        {
          parameter = this.EventArgsConverter.Convert(eventArgs, typeof(object), this.EventArgsConverterParameter, CultureInfo.CurrentUICulture);
        }
      }

      if (this.Command.CanExecute(parameter))
      {
        this.Command.Execute(parameter);
      }
    }
  }
}
#pragma warning restore SA1401