using MultiShop.DAL;

namespace MultiShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MultiShopContext>();
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Slider}/{action=Index}/{id?}"
        );
            app.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}"
                );
            app.Run();
        }
    }
}
