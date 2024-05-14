using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;
using MultiShop.ViewModels;
using MultiShop.ViewModels.Category;
using MultiShop.ViewModels.SendVm;
using MultiShop.ViewModels.Slider;

namespace MultiShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly MultiShopContext _context;

        public HomeController(MultiShopContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders
                .Select(x => new SliderVM
                {
                    Title = x.Title,
                    SubTitle = x.SubTitle,
                    imgUrl = x.imgUrl
                })
                .ToListAsync();

            var categories = await _context.Categories
                .Select(x => new GetCategoryVm { Name = x.Name, Id = x.Id })
                .ToListAsync();

            IndexData indexData = new IndexData
            {
                getCategoryVms = categories,
                GetSliderVMs = sliders
            };

            return View(indexData);
        }

        public async Task<IActionResult> Create()
        { return View(); }


            public async Task<IActionResult> Test() 
        {
            var slider = _context.Sliders.Select(x=>new SliderVM {
            
            Title = x.Title,
            SubTitle = x.SubTitle,
            imgUrl=x.imgUrl
            });
            return View();
        }

        public async Task<IActionResult> Contact( )
        {
            return View();
        }

    }
}
