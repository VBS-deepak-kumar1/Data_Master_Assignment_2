using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakLandlord
    {
        public int LandlordId { get; set; }
        public string LandlordName { get; set; }
        public string LandlordType { get; set; }
        public string LandlordContactInfo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Jurisdiction { get; set; }
        public int? CustId { get; set; }

        public virtual DeepakCustomer Cust { get; set; }
    }
}
