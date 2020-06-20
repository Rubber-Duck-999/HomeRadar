
namespace HomeRadar.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// The following class handles the report created when a scan is performed.
    /// </summary>
    class Report
    {
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
            this.pointsTotal = this.intensiveTotal = this.intrusiveTotal = 100;
        }

        /// <summary>
        /// This function will calculate a score for the report.
        /// </summary>
        /// <returns>
        /// Int
        /// </returns>
        public int CalculateReportTotal()
        {
            return this.pointsTotal;
        }


        /// <summary>
        /// Function called if database found.
        /// </summary>
        public void DatabaseFound(int access_strength)
        {

        }


    }
}
