using System;
using Lateu_Richard_P1.Areas.Identity.Data;
using Lateu_Richard_P1.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


[assembly: HostingStartup(typeof(Lateu_Richard_P1.Areas.Identity.IdentityHostingStartup))]
namespace Lateu_Richard_P1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StoreDBContext>(options => options.UseNpgsql(context.Configuration.GetConnectionString("StoreDB")));
                /*services.AddDbContext<StoreDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("StoreDBContextConnection")));*/

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<StoreDBContext>();
            });
        }
    }
}