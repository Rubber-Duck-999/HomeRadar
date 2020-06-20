// <copyright file="ReportUtils.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// DatabaseAccess is for defining what state the app
    /// could hit a local sql database at.
    /// </summary>
    public enum DatabaseAccess
    {
        None,  // 0 - No database
        Found,  // 1 - SQL Database found
        Remote_Access_Allowed,  // 2 - Allows remote acces
        Remote_Access_Denied,  // 3 - Denies remote access
        No_Password,  // 4 - No password required
        Password_Cracked, // 5 - Password guessed through methods
        Admin_Allowed, // 6 Admin or root is main login
    }

    /// <summary>
    /// Report utils class.
    /// </summary>
    public class ReportUtils
    {
        /// <summary>
        /// None value for report total.
        /// </summary>
        public const int DatabaseNoneValue = 0;

        /// <summary>
        /// Found value for report total.
        /// </summary>
        public const int DatabaseFoundValue = -2;

        /// <summary>
        /// Remote access value for report total.
        /// </summary>
        public const int DatabaseRemoteAccessAllowed = -5;

        /// <summary>
        /// Remote denied value for report total.
        /// </summary>
        public const int DatabaseRemoteAccessDenied = 5;

        /// <summary>
        /// No password value for report total.
        /// </summary>
        public const int DatabaseNoPassword = -10;

        /// <summary>
        /// Password cracked value for report total.
        /// </summary>
        public const int DatabasePasswordCracked = -15;

        /// <summary>
        /// Admin login allowed value for report total.
        /// </summary>
        public const int DatabaseAdminAllowed = -5;

    }
}
