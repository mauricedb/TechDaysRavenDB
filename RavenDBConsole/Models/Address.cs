using System;
using System.Collections;
using System.Collections.Generic;

namespace RavenDBConsole.Models
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }

    public class Order
    {
        public string Company { get; set; }
        public string Employee { get; set; }
        public DateTime OrderedAt { get; set; }
        public Address ShipTo { get; set; }

        public IEnumerable<OrderLine> Lines { get; set; }
    }

    public class OrderLine
    {
        public string Product { get; set; }
        public string ProductName { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}