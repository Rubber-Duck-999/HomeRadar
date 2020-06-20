// <copyright file="ReportFacts.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// ReportFacts is for constant strings of the facts that
    /// will be shown to the user on the report.
    /// </summary>
    public class ReportFacts
    {
        /// <summary>
        /// Weakness in a database on the network.
        /// </summary>
        public const string DatabaseWeakness = "We have found a database on your nwetwork " +
                                        "that has vulnerabilities.";

        /// <summary>
        /// A database was found on the network.
        /// </summary>
        public const string DatabaseFound = "We have found a database on your network";

        /// <summary>
        /// A database has not been found.
        /// </summary>
        public const string DatabaseNotFound = "We haven't found any accessible databases";
    }
}
