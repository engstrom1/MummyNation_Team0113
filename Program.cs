using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MummyNation_Team0113.Data;
using MummyNation_Team0113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MummyNation_Team0113
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await ContextSeed.SeedRolesAsync(userManager, roleManager);
                    await ContextSeed.SeedPharaohAsync(userManager, roleManager);
                    await ContextSeed.SeedPeasantAsync(userManager, roleManager);
                    //string email = "pharaoh@byu.edu";
                    //string password = "chipsahoy311";

                    //if(await userManager.FindByEmailAsync(email) == null)
                    //{
                    //    var user = new ApplicationUser();
                    //    user.Email = email;
                    //    user.EmailConfirmed = true;

                    //    await userManager.CreateAsync(user, password);
                    //    await userManager.AddToRoleAsync(user, "Pharaoh");
                    //    await userManager.AddToRoleAsync(user, "Basic");
                    //}

                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
