using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakLkpManager
    {
        public int AemanagerId { get; set; }
        public int? ConstructionManagerId { get; set; }
        public string ClientCm { get; set; }
        public int? CustId { get; set; }

        public virtual DeepakCustomer Cust { get; set; }
    }
}
