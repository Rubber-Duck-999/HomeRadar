// <copyright file="ILog.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Contracts
{
    /// <summary>
    /// Defines the contract for logging.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// The following method is for verbose logging.
        /// </summary>
        /// <param name="tag">Log tag.</param>
        /// <param name="message">Message to log.</param>
        void Verbose(string tag, string message);

        /// <summary>
        /// The following method is for informational logging.
        /// </summary>
        /// <param name="tag">Log tag.</param>
        /// <param name="message">Message to log.</param>
        void Info(string tag, string message);

        /// <summary>
        /// The following method is for Debug logging.
        /// </summary>
        /// <param name="tag">Log tag.</param>
        /// <param name="message">Message to log.</param>
        void Debug(string tag, string message);

        /// <summary>
        /// The following method is for Error logging.
        /// </summary>
        /// <param name="tag">Log tag.</param>
        /// <param name="message">Message to log.</param>
        void Error(string tag, string message);

        /// <summary>
        /// The following method is for Warning logging.
        /// </summary>
        /// <param name="tag">Log tag.</param>
        /// <param name="message">Message to log.</param>
        void Warn(string tag, string message);
    }
}
