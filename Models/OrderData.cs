using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderData
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public int? UserId { get; set; }
        public int CourierId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public List<OrderDetailData> Details { get; set; }

    }
}
