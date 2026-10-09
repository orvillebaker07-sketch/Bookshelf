
using Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.Controllers
{
    public class BooksController : Controller
    {
        private static readonly List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien", Pages = 310, IsRead = true },
            new Book { Id = 2, Title = "Harry Potter", Author = "J.K. Rowling", Pages = 320, IsRead = true },
            new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Pages = 180, IsRead = false },
            new Book { Id = 4, Title = "1984", Author = "George Orwell", Pages = 328, IsRead = false },
            new Book { Id = 5, Title = "Animal Farm", Author = "George Orwell", Pages = 112, IsRead = true },
            new Book { Id = 6, Title = "The Alchemist", Author = "Paulo Coelho", Pages = 208, IsRead = false }
        };

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult MarkRead(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            book.IsRead = true;

            return RedirectToAction(nameof(Index));
        }
    }
}