using LocalBetBiga.Domain.Repository;
using LocalBetBiga.Domain.Services;
using LocalBetBiga.Interfaces.Repository;
using LocalBetBiga.Interfaces.Services;
using LocalBetBiga.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySQL(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
             .AddCookie(option =>
             {
                 option.LoginPath = "/Manager/Login";
                 option.Cookie.Name = "DotNetGuy";

             });
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminEquipmentDistributionService, AdminEquipmentDistributionService>();
            services.AddScoped<IAdminEquipmentDistributionRepository, AdminEquipmentDistributionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IManagerEquipmentDistributionService, ManagerEquipmentDistributionService>();
            services.AddScoped<IManagerEquipmentDistributionRepository, ManagerEquipmentDistributionRepository>();
            services.AddScoped<IAdminHistoryService, AdminHistoryService>();
            services.AddScoped<IAdminHistoryRepository, AdminHistoryRepository>();
            services.AddScoped<IManagerHistoryRepository, ManagerHistoryRepository>();
            services.AddScoped<IManagerHistoryService, ManagerHistoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
