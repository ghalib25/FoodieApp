using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class CourierData
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string CourierName { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
