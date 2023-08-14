using EF_DataAccess.Data;
using EF_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworks_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.AsNoTracking().ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }

            //edit
            obj = _db.Categories.FirstOrDefault(u => u.Category_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Category_Id == 0)
                {
                    //create reaquest
                    await _db.Categories.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Categories.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category obj = new();

            obj = _db.Categories.FirstOrDefault(u => u.Category_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2(int id)
        {
            List<Category> obj = new List<Category>();
            for (int i = 1; i <= 2; i++)
            {
                obj.Add(
                    new Category
                    {
                        GenreName = Guid.NewGuid().ToString()
                    });
            }
            _db.Categories.AddRange(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5(int id)
        {
            for (int i = 1; i <= 5; i++)
            {
                _db.Categories.Add(
                    new Category
                    {
                        GenreName = Guid.NewGuid().ToString()
                    });

            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple2(int id)
        {
            List<Category> obj = _db.Categories.OrderByDescending(u=>u.Category_Id).Take(2).ToList();          
            _db.Categories.RemoveRange(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveMultiple5(int id)
        {
            List<Category> obj = _db.Categories.OrderByDescending(u => u.Category_Id).Take(5).ToList();
            _db.Categories.RemoveRange(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
