using System.Collections.Generic;

namespace SQRS.Mediatr.Sample.DAL.Entities
{
    public class Customer
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
