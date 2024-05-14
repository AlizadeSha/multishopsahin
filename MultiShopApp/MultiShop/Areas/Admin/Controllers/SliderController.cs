using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;
using MultiShop.Models;
using MultiShop.ViewModels.Slider;

namespace MultiShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly MultiShopContext _context;

        public SliderController(MultiShopContext context)
        {

            _context = context;
        }



        public async Task< IActionResult> Index()
        {
            var data = await _context.Sliders.Where(c => !c.IsDeleted).Select(s => new SliderVM
            {
                Id=s.Id,
                CreatedBy = s.CreatedBy,
                imgUrl = s.imgUrl,
                SubTitle = s.SubTitle,
                Title = s.Title
                


            }).ToListAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            Slider slider = new Slider
            {
                CreatedTime = DateTime.Now,
                imgUrl = vm.ImageUrl,
                IsDeleted = false,
                SubTitle = vm.Subtitle,
                Title = vm.Title,
                
                CreatedBy=vm.CreatedBy
            };

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id) 
        {
            if (id == null && id < 1) { return BadRequest(); }

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id==id);

            if (slider==null)
            {
                return NotFound();
            }

            UpdateSliderVM updatevm = new UpdateSliderVM
            {
                Subtitle=slider.SubTitle,
                Title=slider.Title,
                ImgUrl=slider.imgUrl
            };


            return View(updatevm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSliderVM sliderVM,int? id)
        { 
            if (id == null && id < 1) { return BadRequest(); }
            Slider existed = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (existed == null)
            {
                return NotFound();
            }

            existed.SubTitle = sliderVM.Subtitle;
           existed.Title = sliderVM.Title;
            existed.imgUrl = sliderVM.ImgUrl;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id==null || id<1) return BadRequest();


            var slider = await _context.Sliders.FindAsync(id);
            if (slider==null)
            {
                return NotFound();
            }

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
      

       
    } 
}
