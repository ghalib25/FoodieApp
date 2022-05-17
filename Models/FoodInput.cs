using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public record FoodInput
    (
        int? Id,
        string Name,
        int Stock,
        double Price
    );
}
