using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SA.Application;
using SA.Data;
using SA.Data.Context;
using System.Configuration;
using System.Net;
using System.Text;

internal class Program
{


    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //IoC
        builder.Services.SetDataIoC();
        builder.Services.SetApplicationIoC();


       

        var key = Encoding.ASCII.GetBytes(config["key"]);
        //Authentication
        builder.Services
        .AddAuthentication(x =>
        {
            x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            x.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }).AddCookie(options =>
        {
            options.LoginPath = "/admin/login/login";
            options.LogoutPath = "/admin/login/logout";
        });




        //add sql server
        builder.Services.AddDbContext<SAContext>(x => x.UseSqlServer(config.GetConnectionString("mydb")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication(); // NOTE: line is newly added
        app.UseStaticFiles();

        app.UseRouting();

        

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Login}/{action=Login}/{id?}"
            );
            
            //endpoints.MapControllerRoute(
            //  name: "areas",
            //  pattern: "{area:exists}/{controller=AdminAccount}/{action=Index}/{id?}"
            //);
        });


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}