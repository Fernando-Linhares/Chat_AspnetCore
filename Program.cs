using StringConnection=Chat_AspnetCore.ConnectionStringEnvironment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Chat_AspnetCore.Areas.Identity.Data;

namespace Chat_AspnetCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var dotenv = new DotEnv();

        dotenv.Load();

        var connectionString = new StringConnection();

        builder.Services.AddDbContext<ChatContext>(options => options.UseSqlServer(connectionString.ToString()));

        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ChatContext>();

        builder.Services.AddControllersWithViews();

        builder.Services.AddRazorPages();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
