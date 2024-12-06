namespace MVCofProject.Models
{
    public class Author
    {

        int id;
        string firstName="";
        string lastName="";
        DateTime birthTime;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime BirthTime { get => birthTime; set => birthTime = value; }
        public  Author()
        {

        }

        public Author(int ıd, string firstName, string lastName, DateTime birthTime)
        {
            Id = ıd;
            FirstName = firstName;
            LastName = lastName;
            BirthTime = birthTime;
        }

        public Author(string firstName, string lastName, DateTime birthTime)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthTime = birthTime;
        }
    }
}
