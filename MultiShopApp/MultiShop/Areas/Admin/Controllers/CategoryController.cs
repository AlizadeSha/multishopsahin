using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;
using MultiShop.Models;
using MultiShop.ViewModels.Category;
using MultiShop.ViewModels.Slider;

namespace MultiShop.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly MultiShopContext _context;

        public CategoryController(MultiShopContext context)
        {

            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data=await _context.Categories.Where(x=>!x.IsDeleted).Select(s=> new GetCategoryVm 
            {
            Id = s.Id,
            Name = s.Name,
            }).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create() 
        {
          return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM vm)
        {
            if(!ModelState.IsValid) return View(vm);

            Category category = new Category
            {
                Name = vm.Name,
                CreatedTime = DateTime.Now,
                IsDeleted = false,
                UpdateTime = DateTime.Now,
              
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null && id < 1) { return BadRequest(); }

            Category category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            UpdateCategoryVm updatevm = new UpdateCategoryVm
            {
              Name= category.Name,
            };


            return View(updatevm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateCategoryVm vm) 
        {
            if (id == null && id < 1) { return BadRequest(); }
            Category existed = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);

            if (existed == null)
            {
                return NotFound();
            }

            existed.Name = vm.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();


            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }



    }
    }

