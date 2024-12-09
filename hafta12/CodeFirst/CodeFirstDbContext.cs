
namespace CodeFirst
{
    internal class CodeFirstDbContext : IDisposable
    {
        public object Database { get; internal set; }
    }
}