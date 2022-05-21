using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; } = null!;
        public int CourierId { get; set; }
        public string Longitude { get; set; } = null!;
        public string Latitude { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
