
using BookListWeb.Models;
using BookListWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace BookListWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;   
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (char.IsLower(obj.Name.FirstOrDefault()))
            {
                ModelState.AddModelError("Name", "The category name should start with an uppercase letter.");
            }
            if(ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
           return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepo.Get(u=>u.Id == id);
            if(category == null)
            { 
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepo.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _categoryRepo.Get(u => u.Id==id);
            if(category == null)
            {
                return NotFound();
            }
                _categoryRepo.Delete(category);
                _categoryRepo.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index", "Category");
        }
    }
}
