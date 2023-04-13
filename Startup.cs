using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MummyNation_Team0113.Data;
using System;
using MummyNation_Team0113.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Security.Claims;
using Amazon.SecretsManager;
using Amazon;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MummyNation_Team0113
{
    public class Startup
    {
    //static async Task GetSecret()
    //{
    //    string secretName = "PostgresSQLConnection";
    //    string region = "us-east-1";

    //    IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

    //    GetSecretValueRequest request = new GetSecretValueRequest
    //    {
    //        SecretId = secretName,
    //        VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
    //    };

    //    GetSecretValueResponse response;

    //    try
    //    {
    //        response = await client.GetSecretValueAsync(request);
    //    }
    //    catch (Exception e)
    //    {
    //        // For a list of the exceptions thrown, see
    //        // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
    //        throw e;
    //    }

    //    string secret = response.SecretString;
    //}
    public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure DbContext to use the connection string from AWS Secrets Manager
            //services.AddDbContext<MummyContext>(options =>
            //    options.UseNpgsql(GetSecret().ToString()));

            //var client = new AmazonSecretsManagerClient();
            //var request = new GetSecretValueRequest
            //{
            //    SecretId = "PostgresSQLConnection"
            //};
            //var response = await client.GetSecretValueAsync(request);
            //if (response.SecretString != null)
            //{
            //    // The secret value is a JSON string, so you can deserialize it to get the connection string.
            //    var secret = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.SecretString);
            //    var connectionString = secret["connectionString"];
            //    // Use the connection string to connect to your RDS database.
            //}



            services.AddDbContext<MummyContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("PostgreSQLConnection")));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<IMummyNation_Team0113Repository, EFMummyNation_Team0113Repository>(); // each http request gets its own repository?
            //services.AddScoped<IPurchaseRepository, EFPurchaseRepository>();
            services.AddHsts(options =>
            {
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });
            services.AddControllersWithViews();
            //services.AddAuthentication()
            //    .AddMicrosoftAccount(microsoftOptions =>
            //    {
            //        microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
            //        microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
            //    })
            //    .AddGoogle(options =>
            //    {
            //        IConfigurationSection googleAuthNSection =
            //            Configuration.GetSection("Authentication:Google");

            //        options.ClientId = googleAuthNSection["ClientId"];
            //        options.ClientSecret = googleAuthNSection["ClientSecret"];
            //    });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            app.UseHsts();
            app.UseHttpsRedirection();
            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("Content-Security-Policy",
            //        "default-src 'self'; script-src 'self' https://ajax.googleapis.com https://cdn.jsdelivr.net/npm/cookieconsent@3/build/cookieconsent.min.css; style-src 'self' 'unsafe-inline'; img-src 'self' data:; font-src 'self'; " +
            //        "connect-src 'self'; media-src 'self'; frame-src 'self' https://www.google.com/");
            //    await next();
            //});



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Display",
                    pattern: "{controller=DisplayData}/{action=DisplayData}");
                endpoints.MapControllerRoute(
                    name: "datapage", 
                    pattern: "{data}/Page{pageNum}",
                    new { Controller = "DisplayData", action = "DisplayData" });
                endpoints.MapControllerRoute(
                    name: "paging", 
                    pattern: "Page{pageNum}", 
                    new { Controller = "DisplayData", action = "DisplayData" });
                endpoints.MapControllerRoute(
                    name: "data", 
                    pattern: "{data}", 
                    new { Controller = "DisplayData", action = "DisplayData", pageNum = 1 });
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{controller=RoleManager}/{action=Roles}");
                endpoints.MapRazorPages();
            });

            
        }
    }
}
