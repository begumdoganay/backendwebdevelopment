/*
namespace MvcProjectControllers
{
    public class Order
    {
        public decimal TotalAmount { get; internal set; }
        public int Id { get; internal set; }
        public string ProductName { get; internal set; }
        public decimal Price { get; internal set; }
        public int Quantity { get; internal set; }
        public string Category { get; internal set; }
    }
}

*/









using Microsoft.AspNetCore.Mvc;
using Mvc_ProjectControllers;
using Week8_2_MVCProject.Controllers;

namespace Mvc_Project.Controllers
{
    // Controller responsible for managing customer orders.
    public class CustomerOrdersController(ICustomerService customerService,
                                    IOrderService orderService) : Controller
    {
        private readonly ICustomerService _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        private readonly IOrderService _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));

        // Main action to display customer and their associated orders.
        public IActionResult Index()
        {
            // Retrieve customer by specific ID (hardcoded as 1 for example purposes).
            var customer = _customerService.GetCustomerById(1);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            // Fetch all orders for the given customer.
            var orders = _orderService.GetOrdersByCustomerId(customer.Id);

            // Create view model to pass data to the view.
            CustomerOrderViewModel customerOrderViewModel = new()
            {
                Customer = customer,
                Orders = orders,
                TotalOrderCount = orders.Count(),
                TotalOrderAmount = orders.Sum(o => o.TotalAmount)
            };
            CustomerOrderViewModel viewModel = customerOrderViewModel;

            return View(viewModel);
        }

        // Action to display details of a specific order.
        public IActionResult OrderDetails(int orderId)
        {
            // Retrieve order by its unique identifier.
            var order = _orderService.GetOrderById(orderId);

            // Return 404 if order is not found.
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return View(order);
        }
    }
}
