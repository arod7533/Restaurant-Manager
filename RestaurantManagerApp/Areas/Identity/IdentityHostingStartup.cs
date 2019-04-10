using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagerApp.Areas.Identity.Data;
using RestaurantManagerApp.Models;

[assembly: HostingStartup(typeof(RestaurantManagerApp.Areas.Identity.IdentityHostingStartup))]
namespace RestaurantManagerApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityRestaurantContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<RestaurantManagerUser>()
                    .AddEntityFrameworkStores<IdentityRestaurantContext>();
            });
        }
    }
}