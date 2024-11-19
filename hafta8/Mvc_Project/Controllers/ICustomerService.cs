using MvcProjectControllers;

namespace Week8_2_MVCProject.Controllers
{
    internal interface ICustomerService
    {
        Customer GetCustomerById(int v);
    }
}