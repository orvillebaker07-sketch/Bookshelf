using Bookshelf.Data;
using Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bookshelf.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _db;

        public BooksController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        public IActionResult Details(int id)
        {
            var book = _db.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            ViewBag.LastId = _db.Books.Count();
            return View(book);
        }

        public IActionResult MarkRead(int id)
        {
            var book = _db.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            book.IsRead = true;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult New()
        {
            return View(new Book());
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View("New", book);
            }

            _db.Books.Add(book);
            _db.SaveChanges();

            TempData["Message"] = $"Added {book.Title}";
            return RedirectToAction(nameof(Index));
        }
    }
}