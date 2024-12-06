using Microsoft.AspNetCore.Mvc;
using MVCofProject.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCofProject.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _libraryContext = new LibraryContext();
        private object? _context;

        public IActionResult Index()
        {
            return View(_libraryContext.GetBooksList());
        }
        public IActionResult Details(int id)
        {
            var book = _libraryContext.GetBook(id);
            if (book != null)
            {
                var author = _libraryContext.GetAuthor(book.AuthorId);
                if (author != null)
                {
                    return View(new BookDetails(book, author));
                }
                return View(new BookDetails(book, new Author(-1,"Yazar adi yok", "yazar soy adi yok",DateTime.Now)));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _libraryContext.GetBook(id);
            if (book != null)
            {
                return View(book);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _libraryContext.GetBook(id);
            if (book != null)
            {
                _libraryContext.DeleteBook(id);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var v= _libraryContext.GetAuthorsList();
            ViewData["AuthorList"] = v;
            if(v.Count<1)
            {
                //Yazar yoksa yazar oluşurmaya gider
                return RedirectToAction("Create", "Author");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _libraryContext.CreateBook(book);
                return RedirectToAction("Index");
            }
            ViewData["AuthorList"] = _libraryContext.GetAuthorsList();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var book = _libraryContext.GetBook(id);
            var v= _libraryContext.GetAuthorsList();
            ViewData["AuthorList"] = v;
            if(v.Count<1)
            {
                //hiçbir yazar yoksa düzenleme yapamaz 
                return RedirectToAction("Create", "Author");
            }

            var author = _libraryContext.GetAuthor(book.AuthorId);
            return View(new BookDetails(book,author));
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            
            if (ModelState.IsValid)
            {
                var currentBook = _libraryContext.GetBook(book.Id);
                currentBook.Title = book.Title;
                currentBook.Genre = book.Genre;
                currentBook.CopiesAvailable = book.CopiesAvailable;
                currentBook.PublishDate = book.PublishDate;
                currentBook.AuthorId = book.AuthorId;
            }
            return RedirectToAction("Index");
        }
    }
}
