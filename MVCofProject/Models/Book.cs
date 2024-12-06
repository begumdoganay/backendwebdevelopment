namespace MVCofProject.Models
{
    public class Book
    {
        private int id;
        private int authorId;
        private string isbn = "";
        private DateTime publishDate;
        private string genre = "";
        private string title = "";
        private int copiesAvaliable;

        public int Id { get => id; set => id = value; }
        public int AuthorId { get => authorId; set => authorId = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public DateTime PublishDate { get => publishDate; set => publishDate = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Title { get => title; set => title = value; }
        public int CopiesAvailable { get => copiesAvaliable; set => copiesAvaliable = value; }
        public Book()
        {

        }


        public Book(int ıd, int authorId, string ısbn, DateTime publishDate, string genre, string title, int copiesAvaliable)
        {
            Id = ıd;
            AuthorId = authorId;
            Isbn = ısbn;
            PublishDate = publishDate;
            Genre = genre;
            Title = title;
            CopiesAvailable = copiesAvaliable;
        }

        public Book(int authorId, string ısbn, DateTime publishDate, string genre, string title, int copiesAvaliable)
        {
            AuthorId = authorId;
            Isbn = ısbn;
            PublishDate = publishDate;
            Genre = genre;
            Title = title;
            CopiesAvailable = copiesAvaliable;
        }
    }
}
