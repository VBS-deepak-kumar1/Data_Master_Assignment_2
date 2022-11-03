using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakLkpAddress
    {
        public int Zid { get; set; }
        public string ZipCode { get; set; }
        public int? CustId { get; set; }

        public virtual DeepakCustomer Cust { get; set; }
        public virtual DeepakSiteAddress ZipCodeNavigation { get; set; }
    }
}
