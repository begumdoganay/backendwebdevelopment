
namespace AspDotNetCore.Controllers
{
    internal class HomeViewModel
    {
        public string WelcomeMessage { get; set; }
        public DateTime CurrentTime { get; set; }
        public List<string> FeaturedItems { get; set; }
    }
}