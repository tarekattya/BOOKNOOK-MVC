using Microsoft.EntityFrameworkCore;
using MVCP_BookStore.Models;
using Microsoft.AspNetCore.Identity;
using BookStore.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using BookStore.Services;

namespace MVCP_BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<BookStoreDBContext>(options =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configure Identity with Roles & Email Confirmation Required
            builder.Services.AddIdentity<DefaultUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true; 
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<BookStoreDBContext>()
            .AddDefaultTokenProviders().AddDefaultUI();
            

            // Email Sender Service
            builder.Services.AddSingleton<IEmailSender, EmailSender>();
            builder.Services.AddLogging();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<Cart>(sp => Cart.GetCart(sp));

            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                UserRoleInitializer.InitializeAsync(services).Wait();
            }

            // Configure the HTTP request pipeline.
            app.UseSession();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Store}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages();
            app.Run();
        }
    }
}
