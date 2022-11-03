using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakLkpAssignedTo
    {
        public int Aid { get; set; }
        public string AssignedTo { get; set; }
        public int? CustId { get; set; }

        public virtual DeepakCustomer Cust { get; set; }
    }
}
