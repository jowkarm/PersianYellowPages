using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersianYellowPages.Data;

[assembly: HostingStartup(typeof(PersianYellowPages.Areas.Identity.IdentityHostingStartup))]
namespace PersianYellowPages.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PersianYellowPagesContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PersianYellowPagesContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PersianYellowPagesContext>();
            });
        }
    }
}