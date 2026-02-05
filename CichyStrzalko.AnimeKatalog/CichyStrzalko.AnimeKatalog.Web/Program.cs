using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CichyStrzalko.AnimeKatalog.Web.Data;
using CichyStrzalko.AnimeKatalog.Interfaces;
namespace CichyStrzalko.AnimeKatalog.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CichyStrzalkoAnimeKatalogWebContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CichyStrzalkoAnimeKatalogWebContext") ?? throw new InvalidOperationException("Connection string 'CichyStrzalkoAnimeKatalogWebContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddSingleton(typeof(IDAO),  );
            builder.Services.AddSingleton<BL.BL, BL.BL>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
