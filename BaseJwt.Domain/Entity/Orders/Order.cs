using BaseJWT.Domain.Entity.Common;
using BaseJWT.Domain.Entity.Payment;
using BaseJWT.Domain.Entity.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Domain.Entity.Orders
{
  public class Order
  {
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; }

        public int BillingAddressId { get; set; }

        public int? ShippingAddressId { get; set; }

        public int CustomerId { get; set; }

        public int OrderStatusId { get; set; }

        public int ShippingStatusId { get; set; }

        public int PaymentStatusId { get; set; }

        public decimal OrderTotal { get; set; }

        public decimal RefundedAmount { get; set; }

        public string CardLast4Digit { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public string CustomOrderNumber { get; set; }


        public virtual User Customer { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual Address BillingAddress { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }

        public OrderStatus OrderStatus
        {
            get => (OrderStatus)OrderStatusId;
            set => OrderStatusId = (int)value;
        }

        public PaymentStatus PaymentStatus
        {
            get => (PaymentStatus)PaymentStatusId;
            set => PaymentStatusId = (int)value;
        }

        public ShippingStatus ShippingStatus
        {
            get => (ShippingStatus)ShippingStatusId;
            set => ShippingStatusId = (int)value;
        }

    }
}
