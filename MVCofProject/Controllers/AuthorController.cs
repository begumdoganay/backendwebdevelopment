using Microsoft.AspNetCore.Mvc;
using MVCofProject.Models;

namespace MVCofProject.Controllers
{
    public class AuthorController : Controller
    {
        LibraryContext libraryContext = new LibraryContext();
        public IActionResult Index()
        {
            return View(libraryContext.GetAuthorsList());
        }
        public IActionResult Details(int id)
        {
            var author = libraryContext.GetAuthor(id);
            if (author != null)
            {
                return View(author);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = libraryContext.GetAuthor(id);
            if (author != null)
            {
                return View(author);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = libraryContext.GetAuthor(id);
            if (author != null)
            {
                libraryContext.DeleteAuthor(id);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["AuthorList"] = libraryContext.GetAuthorsList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                libraryContext.CreateAuthor(author);
                return RedirectToAction("Index");
            }
            ViewData["AuthorList"] = libraryContext.GetAuthorsList();
            return View();
        }
        public ActionResult Edit(int id)
        {
            var author = libraryContext.GetAuthor(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {

            if (ModelState.IsValid)
            {
                var currentAuthor = libraryContext.GetAuthor(author.Id);
                currentAuthor.FirstName = author.FirstName;
                currentAuthor.LastName = author.LastName;
                currentAuthor.BirthTime = author.BirthTime;

            }
            return RedirectToAction("Index");
        }


    }
}
