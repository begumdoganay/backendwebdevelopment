using MVCofProject.Models;
using System.Linq;

namespace MVCofProject.Controllers
{
    public class LibraryContext
    {
        static List<Book> bookTableList = new List<Book>{ };
        static List<Author> authorTableList = new List<Author> { };
        public static void TableInitialize()
        {
            bookTableList = new List<Book>
{
    new Book(1,1, "978-0-385-42164-6", new DateTime(1997, 9, 15), "Fantasy", "Harry Potter and the Philosopher's Stone", 50),
    new Book(2,2, "978-0-452-28423-4", new DateTime(1949, 6, 8), "Dystopian", "1984", 30),
    new Book(3,3, "978-0-060-93546-5", new DateTime(1960, 7, 11), "Novel", "To Kill a Mockingbird", 45),
    new Book(4,4, "978-0-316-76948-0", new DateTime(2005, 3, 22), "Science Fiction", "The Hitchhiker's Guide to the Galaxy", 40),
    new Book(5,5, "978-0-553-38286-6", new DateTime(1994, 10, 1), "Historical Fiction", "Gone with the Wind", 35),
    new Book(6,6, "978-0-674-27752-5", new DateTime(2018, 5, 15), "Biography", "Leonardo da Vinci", 25),
    new Book(7,7, "978-0-441-78592-3", new DateTime(1968, 11, 30), "Mystery", "Murder on the Orient Express", 55),
    new Book(8,8, "978-0-062-31030-3", new DateTime(2010, 2, 16), "Young Adult", "The Hunger Games", 60),
    new Book(9,9, "978-0-743-26715-5", new DateTime(1925, 4, 10), "Classic", "The Great Gatsby", 40),
    new Book(10,10, "978-1-400-03115-3", new DateTime(2003, 12, 1), "Fantasy", "The Name of the Wind", 45)
};


            authorTableList = new List<Author>
{
    new Author(1, "J.K.", "Rowling", new DateTime(1965, 7, 31)),
    new Author(2, "George", "Orwell", new DateTime(1903, 6, 25)),
    new Author(3, "Harper", "Lee", new DateTime(1926, 4, 28)),
    new Author(4, "Douglas", "Adams", new DateTime(1952, 3, 11)),
    new Author(5, "Margaret", "Mitchell", new DateTime(1900, 11, 8)),
    new Author(6, "Walter", "Isaacson", new DateTime(1952, 5, 20)),
    new Author(7, "Agatha", "Christie", new DateTime(1890, 9, 15)),
    new Author(8, "Suzanne", "Collins", new DateTime(1962, 8, 10)),
    new Author(9, "F. Scott", "Fitzgerald", new DateTime(1896, 9, 24)),
    new Author(10, "Patrick", "Rothfuss", new DateTime(1973, 6, 6))
};
        }

        public Book GetBook(int id)
        {
            return bookTableList.Where(currentBook => currentBook.Id== id).FirstOrDefault();
        }
        public void CreateBook(Book book)
        {
            int bookId = 0;
            if (bookTableList.Count>0)
            {
                bookId=bookTableList.Max(currentBook => currentBook.Id)+1;
            }
            book.Id = bookId;
            bookTableList.Add(book);
        }
        public void DeleteBook(int id)
        {
            bookTableList.Remove(bookTableList.Where(currentBook => currentBook.Id == id).FirstOrDefault());

        }
        public List<Book> GetBooksList()
        {
            return bookTableList;
        }
        //
        public Author GetAuthor(int id)
        {
            return authorTableList.Where(currentAuthor => currentAuthor.Id == id).FirstOrDefault();
        }
        public void CreateAuthor(Author author)
        {
            int authorId = 0;
            if (authorTableList.Count > 0)
            {
                authorId = authorTableList.Max(currentAuthor => currentAuthor.Id) + 1;
            }
            author.Id = authorId;
            authorTableList.Add(author);
        }
        public void DeleteAuthor(int id)
        {
            authorTableList.Remove(authorTableList.Where(currentAuthor => currentAuthor.Id == id).FirstOrDefault());

        }
        public List<Author> GetAuthorsList()
        {
            return authorTableList;
        }



    }
}