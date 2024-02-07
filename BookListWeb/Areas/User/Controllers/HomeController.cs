using BookListWeb.Models;
using BookListWeb.Repository;
using BookListWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookListWeb.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;
        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _bookRepository.GetAll(includeProperties: "Category");
            return View(books);
        }

        public IActionResult Details(int? bookId)
        {
            Book? book = _bookRepository.Get(u => u.Id == bookId, includeProperties: "Category");
            return View(book);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}