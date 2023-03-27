using Microsoft.EntityFrameworkCore;
using TesteEF.Models.Service;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Packaging;
using TesteEF.Data;
namespace TesteEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var result = builder.Services.AddDbContext<TesteEFContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TesteEFContext") ?? throw new InvalidOperationException("Connection string 'TesteEFContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<SeedingService>();

            builder.Services.AddScoped<SellerService>();

            builder.Services.AddScoped<DepartmentsService>();

            var app = builder.Build();

            SeedDatabase();

            void SeedDatabase()
            {
                using (var scope = app.Services.CreateScope())
                    try
                    {
                        var scopedContext = scope.ServiceProvider.GetRequiredService<TesteEFContext>();
                        SeedingService.Seed(scopedContext);
                    }
                    catch
                    {
                        throw;
                    }
            }



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else if(app.Environment.IsDevelopment())


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