using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreDL;
using StoreBL;
using Microsoft.AspNetCore.Identity;
using StoreModels;

namespace StoreWebUI
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
            services.AddRazorPages();
            services.AddDbContext<StoreDBContext>(options=>options.UseNpgsql(Configuration.GetConnectionString("StoreDB")));
            services.AddScoped<ICustomerDL, CustomerDL>();
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<ILocationDL, LocationDL>();
            services.AddScoped<ILocationBL, LocationBL>();

            services.AddScoped<IProductDL, ProductDL>();
            services.AddScoped<IProductBL, ProductBL>();

            //services.AddScoped()


            services.AddScoped<IOrderDL, OrderDL>();
            services.AddScoped<IOrderBL, OrderBL>();

            services.AddScoped<IInventoryBL, InventoryBL>();
            services.AddScoped<IInventoryDL, InventoryDL>();

            services.AddScoped<IItemBL, ItemBL>();
            services.AddScoped<OrderItemDL, ItemDL>();


            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength=2;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                 .AddDefaultUI()
                 .AddDefaultTokenProviders()
                 .AddEntityFrameworkStores<StoreDBContext>();
            //

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
                endpoints.MapRazorPages();
            });
        }
    }
}
