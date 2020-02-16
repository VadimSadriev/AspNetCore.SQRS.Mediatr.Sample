namespace SQRS.Mediatr.Sample.DAL.Entities
{
    public class Order
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
