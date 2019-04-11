using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWT.Domain.Entity.Orders
{
    public enum OrderStatus
    {
        /// <summary>
        /// Pending
        /// </summary>
        Pending = 10,

        /// <summary>
        /// Processing
        /// </summary>
        Processing = 20,

        /// <summary>
        /// Complete
        /// </summary>
        Complete = 30,

        /// <summary>
        /// Cancelled
        /// </summary>
        Cancelled = 40
    }
}
