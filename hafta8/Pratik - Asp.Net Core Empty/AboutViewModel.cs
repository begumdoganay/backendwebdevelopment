namespace AspDotNetCore.Controllers
{
    internal class AboutViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
    }
}