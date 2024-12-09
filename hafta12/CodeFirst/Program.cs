using CodeFirst;
using CodeFirstBasic.Model.Context;

namespace CodeFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new CodeFirstDbContext();
            // Create database
            object value = context.Database.DbContext();
            Console.WriteLine("Veritabaný baþarýyla oluþturuldu.");
        }
    }
}