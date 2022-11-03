using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakCustomer
    {
        public DeepakCustomer()
        {
            DeepakLandlords = new HashSet<DeepakLandlord>();
            DeepakLkpAddresses = new HashSet<DeepakLkpAddress>();
            DeepakLkpAssignedTos = new HashSet<DeepakLkpAssignedTo>();
            DeepakLkpManagers = new HashSet<DeepakLkpManager>();
            DeepakLkpSiteTypes = new HashSet<DeepakLkpSiteType>();
            DeepakLkpStatuses = new HashSet<DeepakLkpStatus>();
            DeepakSites = new HashSet<DeepakSite>();
        }

        public int CustomerId { get; set; }
        public string CustomerSite { get; set; }
        public string CustomerRegion { get; set; }
        public string CustomerMarket { get; set; }

        public virtual ICollection<DeepakLandlord> DeepakLandlords { get; set; }
        public virtual ICollection<DeepakLkpAddress> DeepakLkpAddresses { get; set; }
        public virtual ICollection<DeepakLkpAssignedTo> DeepakLkpAssignedTos { get; set; }
        public virtual ICollection<DeepakLkpManager> DeepakLkpManagers { get; set; }
        public virtual ICollection<DeepakLkpSiteType> DeepakLkpSiteTypes { get; set; }
        public virtual ICollection<DeepakLkpStatus> DeepakLkpStatuses { get; set; }
        public virtual ICollection<DeepakSite> DeepakSites { get; set; }
    }
}
