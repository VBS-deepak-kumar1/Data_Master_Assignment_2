using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakSite
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProjectManager { get; set; }
        public string RealEstateSpecialist { get; set; }
        public string FieldCoordinator { get; set; }
        public string SiteAcqVendor { get; set; }
        public string CivilVendor { get; set; }
        public string ConstructionVendor { get; set; }
        public string AeFirm { get; set; }
        public int? CustId { get; set; }

        public virtual DeepakCustomer Cust { get; set; }
    }
}
