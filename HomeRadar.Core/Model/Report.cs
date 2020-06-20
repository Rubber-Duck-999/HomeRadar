// <copyright file="Report.cs" company="FutureInnovationTech">
// Copyright (c) FutureInnovationTech. All rights reserved.
// </copyright>

namespace HomeRadar.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The following class handles the report created when a scan is performed.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Min value for totals.
        /// </summary>
        private const int Min = 0;

        /// <summary>
        /// Max value for totals.
        /// </summary>
        private const int Max = 100;

        /// <summary>
        /// Collection of devices on the network.
        /// </summary>
        private int devicesTotal;

        /// <summary>
        /// Points total collected, set to max initially.
        /// </summary>
        private int pointsTotal;

        /// <summary>
        /// Intrusive checks total.
        /// </summary>
        private int intrusiveTotal;

        /// <summary>
        /// Intensive total report number.
        /// </summary>
        private int intensiveTotal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Report"/> class.
        /// Report constructor.
        /// </summary>
        public Report()
        {
            this.pointsTotal = this.intensiveTotal = this.intrusiveTotal = 0;
        }

        /// <summary>
        /// This function will calculate a score for the report.
        /// </summary>
        /// <returns>
        /// Int
        /// </returns>
        public int CalculateReportTotal()
        {
            this.pointsTotal = this.intensiveTotal +
                                this.intrusiveTotal;
            if (this.pointsTotal < Min)
            {
                this.pointsTotal = Min;
            }
            else if (this.pointsTotal > Max)
            {
                this.pointsTotal = Max;
            }

            return this.pointsTotal;
        }

        /// <summary>
        /// Function called if database found.
        /// </summary>
        /// <param name="access_strength">
        /// Enum for access on database on network.
        /// </param>
        public void DatabaseFound(DatabaseAccess access_strength)
        {
            switch (access_strength)
            {
                case DatabaseAccess.None:
                    this.UpdateIntrusiveTotal(5);
                    break;
                case DatabaseAccess.Found:
                    this.UpdateIntrusiveTotal(-1);
                    break;
                case DatabaseAccess.Remote_Access_Denied:
                    this.UpdateIntrusiveTotal(7);
                    break;
                case DatabaseAccess.Remote_Access_Allowed:
                    this.UpdateIntrusiveTotal(-5);
                    break;
                case DatabaseAccess.No_Password:
                    this.UpdateIntrusiveTotal(-15);
                    break;
                case DatabaseAccess.Password_Cracked:
                    this.UpdateIntrusiveTotal(-10);
                    break;
                case DatabaseAccess.Admin_Allowed:
                    this.UpdateIntrusiveTotal(-5);
                    break;
                default:
                    this.UpdateIntrusiveTotal(0);
                    break;
            }
        }

        /// <summary>
        /// Update function to ensure doesn't go above or below max or min with
        /// updated value.
        /// </summary>
        /// <param name="update">
        /// Value to update total with.
        /// </param>
        private void UpdateIntrusiveTotal(int update)
        {
            // Checks whether its less than min if so set value to min
            if ((this.intrusiveTotal - update) >= Min)
            {
                // Checks whether its more than max and if so set to max
                if ((this.intrusiveTotal + update) <= Max)
                {
                    this.intrusiveTotal += update;
                }
                else
                {
                    this.intrusiveTotal = 100;
                }
            }
            else
            {
                this.intrusiveTotal = 0;
            }
        }

        /// <summary>
        /// Update function to ensure doesn't go above or below max or min.
        /// </summary>
        /// <param name="update">
        /// Value to update total with.
        /// </param>
        private void UpdateIntensiveTotal(int update)
        {
            // Checks whether its less than min if so set value to min
            if ((this.intensiveTotal - update) >= Min)
            {
                // Checks whether its more than max and if so set to max
                if ((this.intensiveTotal + update) <= Max)
                {
                    this.intensiveTotal += update;
                }
                else
                {
                    this.intensiveTotal = 100;
                }
            }
            else
            {
                this.intensiveTotal = 0;
            }
        }
    }
}
