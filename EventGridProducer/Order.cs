using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventHubProducer
{
    internal class Order
    {
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
