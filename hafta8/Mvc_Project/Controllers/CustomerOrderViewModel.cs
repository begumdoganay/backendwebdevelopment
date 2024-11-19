using MvcProjectControllers;

namespace Mvc_ProjectControllers
{
    internal class CustomerOrderViewModel
    {
        public CustomerOrderViewModel()
        {
        }

        public CustomerOrderViewModel(List<Order> orders)
        {
            this.Orders = orders;
        }

        public required Customer Customer { get; set; }
        public required List<Order> Orders { get; set; }
        public required string Greetings { get; set; }
        public required object OrderStatistics { get; set; }
        public int TotalOrderCount { get; internal set; }
        public int TotalOrderAmount { get; internal set; }
    }
}