using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            // built in service need to register ==> connection string
            // register option , Context
            builder.Services.AddDbContext<Context>(optionBuilder => {
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>( 
                Options => 
                {
                    Options.Password.RequireNonAlphanumeric = false;
                    Options.Password.RequiredLength = 4;
                })
                .AddEntityFrameworkStores<Context>();




            //builder.Services.AddScoped<ICourseRepository, CourseFromMemoryRepository>();  // Register
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();  // Register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
