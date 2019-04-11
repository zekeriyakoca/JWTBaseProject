﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWT.Domain.Entity.Payment
{
    public enum PaymentStatus
    {
        /// <summary>
        /// Pending
        /// </summary>
        Pending = 10,

        /// <summary>
        /// Authorized
        /// </summary>
        Authorized = 20,

        /// <summary>
        /// Paid
        /// </summary>
        Paid = 30,

        /// <summary>
        /// Partially Refunded
        /// </summary>
        PartiallyRefunded = 35,

        /// <summary>
        /// Refunded
        /// </summary>
        Refunded = 40,

        /// <summary>
        /// Voided
        /// </summary>
        Voided = 50
    }
}
