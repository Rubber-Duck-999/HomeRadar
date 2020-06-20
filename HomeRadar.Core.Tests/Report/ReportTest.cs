// <copyright file="ReportTest.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Tests.Report
{
    using System;
    using FluentAssertions;
    using HomeRadar.Core.Model;
    using Xunit;
    using Report = Model.Report;

    /// <summary>
    /// Performs tests to confirm if a device is connected to a network.
    /// </summary>
    public class ReportTest
    {
        /// <summary>
        /// Tests if report is initialised to min correctly
        /// </summary>
        [Fact]
        public void Report_InitialisePoints()
        {
            // Arrange
            var report = new Report();
            Assert.Equal(0, report.CalculateReportTotal());
        }

        /// <summary>
        /// Test to check if points get changed correctly based of whether a sql database is found.
        /// </summary>
        [Fact]
        public void Report_DatabaseFound()
        {
            // First create a report
            var report = new Report();

            // Add that no databases have been found
            DatabaseAccess none = DatabaseAccess.None;
            report.DatabaseFound(none);

            // Get report total which should be equal
            // to the none value for databases found
            Assert.Equal(ReportUtils.DatabaseNoneValue, 
                report.CalculateReportTotal());

            // Add that a database was found but 
            // no remote access allowed
            DatabaseAccess remote_denied = DatabaseAccess.Remote_Access_Denied;
            report.DatabaseFound(remote_denied);

            // Again get report total
            Assert.Equal(ReportUtils.DatabaseRemoteAccessDenied, report.CalculateReportTotal());
        }
    }
}
