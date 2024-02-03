
using BookListWeb.Data;
using BookListWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookListWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> objBookList = _db.Books.ToList();
            return View(objBookList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
