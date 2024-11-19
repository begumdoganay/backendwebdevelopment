using Mvc_ProjectControllers;

namespace MvcProjectControllers
{
    internal class Customer
    {
        public int Id { get; internal set; }
        public required string FirstName { get; internal set; }
        public required string LastName { get; internal set; }
        public required string PhoneNumber { get; internal set; }
        public required string Email { get; internal set; }

        internal class OrderViewModel
        {
            public required Customer Customer { get; set; }
            public List<Order>? Orders { get; set; }
            public int TotalOrderCount { get; set; }
            public int TotalOrderAmount { get; set; }
        }
    }
}