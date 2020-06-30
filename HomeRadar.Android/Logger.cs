// <copyright file="Logger.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

using Xamarin.Forms;
[assembly: Dependency(typeof(HomeRadar.Droid.Logger))]
namespace HomeRadar.Droid
{
    using Android.Util;
    using Contracts;

    /// <summary>
    /// Android logger
    /// </summary>
    public class Logger : ILog
    {
        /// <inheritdoc/>
        public void Debug(string tag, string message)
        {
            Log.Debug(tag, message);
        }

        /// <inheritdoc/>
        public void Error(string tag, string message)
        {
            Log.Error(tag, message);
        }

        /// <inheritdoc/>
        public void Info(string tag, string message)
        {
            Log.Info(tag, message);
        }

        /// <inheritdoc/>
        public void Verbose(string tag, string message)
        {
            Log.Verbose(tag, message);
        }

        /// <inheritdoc/>
        public void Warn(string tag, string message)
        {
            Log.Warn(tag, message);
        }
    }
}
