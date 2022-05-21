using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Courier
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CourierName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool? Status { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
