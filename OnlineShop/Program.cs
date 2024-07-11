using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using OnlineStore.Abstractions;
using OnlineStore.Repositories;
using OnlineStore.Services;
using Microsoft.AspNetCore.Identity;
using OnlineStore.Models.DbModels;
using Microsoft.Extensions.Options;

namespace OnlineShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IRacketRepository, RacketRepository>();
            builder.Services.AddScoped<RacketService>();

            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<BrandService>();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<OnlineStoreContext>(options => options.UseSqlServer(connection));

            builder.Services.AddDefaultIdentity<OnlineStoreUser>(options => {

                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;

                options.SignIn.RequireConfirmedEmail = false;


            }).AddEntityFrameworkStores<OnlineStoreContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.ExpireTimeSpan = TimeSpan.FromSeconds(10);
                options.SlidingExpiration = true;
            });

            builder.Services.AddScoped<PasswordHasher<OnlineStoreUser>>();

            var app = builder.Build();

            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
