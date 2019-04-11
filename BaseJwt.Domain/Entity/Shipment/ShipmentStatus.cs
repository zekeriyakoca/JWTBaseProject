using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWT.Domain.Entity.Shipment
{
    public enum ShippingStatus
    {
        /// <summary>
        /// Shipping not required
        /// </summary>
        ShippingNotRequired = 10,

        /// <summary>
        /// Not yet shipped
        /// </summary>
        NotYetShipped = 20,

        /// <summary>
        /// Partially shipped
        /// </summary>
        PartiallyShipped = 25,

        /// <summary>
        /// Shipped
        /// </summary>
        Shipped = 30,

        /// <summary>
        /// Delivered
        /// </summary>
        Delivered = 40
    }
}
