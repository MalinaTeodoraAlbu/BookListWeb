
using BookListWeb.Data;
using BookListWeb.Models;
using BookListWeb.Repository.IRepository;
using BookListWeb.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookListWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IBookRepository db, ICategoryRepository categoryRepo, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepo = db;
            _categoryRepo = categoryRepo;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Book> objBookist = _bookRepo.GetAll(includeProperties:"Category").ToList();

            return View(objBookist);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _categoryRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            BookVM bookVM = new()
            {
                Book = new Book(),
                CategoryList = CategoryList
            };
            
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Create(BookVM obj, IFormFile? file)
        {
 
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\books");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    Console.WriteLine(fileName);
                    obj.Book.ImageUrl = @"\images\books\" + fileName;
                    Console.WriteLine(obj.Book.ImageUrl);
                }
                _bookRepo.Add(obj.Book);
                _bookRepo.Save();
                TempData["success"] = "Book created successfully";
                return RedirectToAction("Index", "Book");
            }
            else
            {
                obj.CategoryList = _categoryRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(obj);

            }

            
        }

        public IActionResult Edit(int? id)
        {
            BookVM bookVM = new()
            {
                CategoryList = _categoryRepo.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Book = new Book()
            };
            if (id == null || id == 0)
            {
                return NotFound();
            }
            bookVM.Book = _bookRepo.Get(u => u.Id == id);
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Edit(BookVM obj, IFormFile? file)
        {
     
            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\books");

                    if (!string.IsNullOrEmpty(obj.Book.ImageUrl))
                    {

                        var oldImagePath = Path.Combine(wwwRootPath, obj.Book.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    Console.WriteLine(fileName);
                    obj.Book.ImageUrl = @"\images\books\" + fileName;
                }

                _bookRepo.Update(obj.Book);
                _bookRepo.Save();
                TempData["success"] = "Book updated successfully";
                return RedirectToAction("Index", "Book");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book? book = _bookRepo.Get(u => u.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Book? book = _bookRepo.Get(u => u.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepo.Delete(book);
            _bookRepo.Save();
            TempData["success"] = "Book deleted successfully";
            return RedirectToAction("Index", "Book");
        }


        
    }
}

