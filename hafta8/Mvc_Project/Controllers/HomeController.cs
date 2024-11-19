using Microsoft.AspNetCore.Mvc;
using MvcProjectControllers;

namespace Mvc_ProjectControllers
{

    // Manages customer and order interactions in the digital marketplace
    // Handles data presentation and business logic for customer transactions
  
    public class CustomerOrdersController : Controller
    {
        // Simulated data service (in real-world scenario, this would be a database context)
        public readonly ICustomerDataService _dataService;

      
        // Constructor for dependency injection of data services
        // Enables flexible and testable data management
        
        public CustomerOrdersController(ICustomerDataService dataService)
        {
            _dataService = dataService;
        }

        
        // Primary action method for displaying customer order dashboard
        // Generates a comprehensive view of customer profile and order history
        
        // View with customer and order information
        public IActionResult Index()
        {
            // Create a sample customer with realistic profile data
            Customer customer = new()
            {
                Id = GenerateUniqueCustomerId(),
                FirstName = "Sütlü Nuriye",
                LastName = "Doðanay",
                Email = "vanliyamsanliyam6565@gmail.com",
                PhoneNumber = "+90536 664 5260" // veli numarasý --> Veli: sevimsiz begüm 
            };

            // Generate a diverse set of product orders
            List<Order> orders = GenerateSampleOrders();

            // Construct view model with enriched customer experience
            CustomerOrderViewModel viewModel = new CustomerOrderViewModel
            {
                Customer = customer,
                Orders = orders,
                Greetings = GeneratePersonalizedGreeting(customer),
                OrderStatistics = new OrderStatistics
                {
                    TotalOrderCount = orders.Count,
                    TotalOrderValue = orders.Sum(o => o.TotalAmount),
                    AverageOrderValue = orders.Average(o => o.TotalAmount)
                }
            };

            // Log customer access for analytics
            LogCustomerDashboardAccess(customer.Id);

            return View(viewModel);
        }

        
        // Generates a unique customer ID
        // Simulates real-world ID generation strategy
        
        private int GenerateUniqueCustomerId()
        {
            // In a real system, this would be handled by the database
            return new Random().Next(1000, 9999);
        }

        
        // Creates a sample list of product orders
        // Demonstrates variety in product selection and ordering
      
        private List<Order> GenerateSampleOrders()
        {
            return new List<Order>
           {
               CreateOrder(1, "Ayþe Teyze Fasulyesi ", 15.99m, 2, "Gýda"),
               CreateOrder(2, "Otlu Peynir", 120.50m, 3, "Evcil Hayvan"),
               CreateOrder(3, "Kuru et", 7.50m, 6, "Atýþtýrmalýk"),
               CreateOrder(4, "Özel Ton Balýðý", 35.75m, 2, "Deniz Ürünleri")
           };
        }

 
        // Factory method for creating order instances with additional context
        
        public Order CreateOrder(int id, string productName, decimal price, int quantity, string category)
        {
            return new Order
            {
                Id = id,
                ProductName = productName,
                Price = price,
                Quantity = quantity,
                Category = category
            };
        }

        // Generates a personalized greeting based on customer profile
        private string GeneratePersonalizedGreeting(Customer customer)
        {
            string[] greetings = {
               $"Merhaba {customer.FirstName}, size özel fýrsatlarýmýz var!",
               $"Hoþgeldiniz efeniiiiim, Þipþak Market'e tekrar hoþgeldiniz, {customer.FirstName}!",
               $"Bugün ne almak istersiniz, sayýn {customer.FirstName}?"
           };

            return greetings[new Random().Next(greetings.Length)];
        }

      
        // Logs customer dashboard access for analytics and tracking
        
        private void LogCustomerDashboardAccess(int customerId)
        {
            // In a real system, this would log to a database or logging service
            System.Diagnostics.Debug.WriteLine($"Customer #{customerId} accessed dashboard at {System.DateTime.Now}");
        }
    }

    // Placeholder interface for data service
    public interface ICustomerDataService
    {
        // Future database operations would be defined here
    }
}