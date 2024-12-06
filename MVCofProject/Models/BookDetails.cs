namespace MVCofProject.Models
{
    public class BookDetails
    {
        public Book book;
        public Author author;
        public BookDetails(Book book, Author author)
        {
            this.book = book;
            this.author = author;
        }
    }
}
