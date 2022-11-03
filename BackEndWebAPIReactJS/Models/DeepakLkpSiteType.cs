using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakLkpSiteType
    {
        public int SiteTypeId { get; set; }
        public string SiteType { get; set; }
        public int? CustId { get; set; }

        public virtual DeepakCustomer Cust { get; set; }
    }
}
