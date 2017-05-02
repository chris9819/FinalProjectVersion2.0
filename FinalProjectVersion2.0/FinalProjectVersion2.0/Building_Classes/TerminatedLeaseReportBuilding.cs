using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVersion2._0.Building_Classes
{
    /// <summary>
    /// This class represents a single building in the terminated leases excel report from Propertyware.
    /// </summary>
    public class TerminatedLeaseReportBuilding : Building
    {
        /// <summary>
        /// Represents the value in the "Portfolio Abbreviation" column in the terminated leases excel report.
        /// </summary>
        public string PortfolioAbbreviation { get; set; }
        /// <summary>
        /// Represents the value in the "Payee/Payer" column in the terminated leases excel report.
        /// </summary>
        public string PayeePayer { get; set; }
        /// <summary>
        /// Represents the value in the "Date" column in the terminated leases excel report.
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Represents the value in the "Charge Amount" column in the terminated leases excel report.
        /// </summary>
        public double ChargeAmount { get; set; }
        /// <summary>
        /// Represents the value in the "Account Number" column in the terminated leases excel report.
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Represents the value in the "Account Description" column in the terminated leases excel report.
        /// </summary>
        public string AccountDescription { get; set; }
    }
}
