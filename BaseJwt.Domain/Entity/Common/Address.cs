using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWT.Domain.Entity.Common
{
    public class Address : BaseEntity
    {
        public string AddressName { get; set; }

        public string County { get; set; }

        public string City { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipPostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string CustomAttributes { get; set; }

        public DateTime CreatedOnUtc { get; set; }

    }
}
