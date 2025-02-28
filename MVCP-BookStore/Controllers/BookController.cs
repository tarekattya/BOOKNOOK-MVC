using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MVCP_BookStore.Models;
using MVCP_BookStore.ViewModels;

namespace MVCP_BookStore.Controllers
{

    [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        BookStoreDBContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly string _imagePath;
        public BookController(BookStoreDBContext context, IWebHostEnvironment host)
        {
            _context = context;
            _environment = host;
            _imagePath = $"{_environment.WebRootPath}/images";

        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }





        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Books
                .FirstOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult create(BookVM book)
        {
            if (ModelState.IsValid)
            {

                string imageName = $"{Guid.NewGuid()}{Path.GetExtension(book.ImageUrl.FileName)}";
                var path = Path.Combine(_imagePath, imageName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    book.ImageUrl.CopyTo(stream);

                }

                Book book1 = new Book()
                {
                    Author = book.Author,
                    DatePublished = book.DatePublished,
                    Description = book.Description,
                    ISBN = book.ISBN,
                    ImageUrl = $"/images/{imageName}",
                    Language = book.Language,
                    Price = book.Price,
                    Title = book.Title,
                };
                _context.Add(book1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book1 = new BookVM();
            var book = _context.Books.Find(id);
            book1.Description = book.Description;
            book1.Title = book.Title;
            book1.Price = book.Price;
            book1.Author = book.Author;
            book1.ISBN = book.ISBN;
            book1.DatePublished = book.DatePublished;
            book1.Language = book.Language;
            book1.CurrentImageUrl = book.ImageUrl;
            if (book == null)
            {
                return NotFound();
            }
            return View(book1);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookVM book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string imageName = $"{Guid.NewGuid()}{Path.GetExtension(book.ImageUrl.FileName)}";
                var path = Path.Combine(_imagePath, imageName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    book.ImageUrl.CopyTo(stream);

                }
                var book1 = _context.Books.Find(id);
                book1.Description = book.Description;
                book1.Title = book.Title;
                book1.Price = book.Price;
                book1.Author = book.Author;
                book1.ISBN = book.ISBN;
                book1.DatePublished = book.DatePublished;
                book1.Language = book.Language;
                book1.ImageUrl = $"/images/{imageName}";

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Books.FirstOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }




        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }



















    }
}
