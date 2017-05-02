using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVersion2._0.Building_Classes
{
    /// <summary>
    /// This class represents a single building in the new leases excel report from Propertyware.
    /// </summary>
    public class NewLeaseReportBuilding: Building
    {
        /// <summary>
        /// Represents the value in the "Portfolio Name" column in the new leases excel report.
        /// </summary>
        public string PortfolioName { get; set; }
        /// <summary>
        /// Represents the value in the "Status" column in the new leases excel report.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Represents the value in the "Advertising Start Date" column in the new leases excel report.
        /// </summary>
        public string AdvertisingStartDate { get; set; }
        /// <summary>
        /// Represents the value in the "Property Leased Date" column in the new leases excel report.
        /// </summary>
        public string PropertyLeasedDate { get; set; }
        /// <summary>
        /// Represents the value in the "Rent Amount On Lease" column in the new leases excel report.
        /// </summary>
        public double RentAmountOnLease { get; set; }
        /// <summary>
        /// Represents the value in the "Managment Begin Date" column in the new leases excel report.
        /// </summary>
        public string ManagementBeginDate { get; set; }
    }
}
