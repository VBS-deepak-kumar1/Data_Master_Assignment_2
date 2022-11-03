using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakSiteAddress
    {
        public DeepakSiteAddress()
        {
            DeepakLkpAddresses = new HashSet<DeepakLkpAddress>();
        }

        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? CustId { get; set; }

        public virtual ICollection<DeepakLkpAddress> DeepakLkpAddresses { get; set; }
    }
}
