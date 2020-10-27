using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Expense;
using SplitwiseApp.Repository.Friend;
using SplitwiseApp.Repository.Group;
using SplitwiseApp.Repository.GroupMember;
using SplitwiseApp.Repository.Payees_Expense;
using SplitwiseApp.Repository.Payers_Expense;
using SplitwiseApp.Repository.Settlements;
using SplitwiseApp.Repository.User;
using Newtonsoft.Json.Serialization;

namespace SplitwiseApp.Web
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
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUser, MockUser>();
            services.AddScoped<IExpenses, MockExpenses>();
            services.AddScoped<IFriends, MockFriends>();
            services.AddScoped<IGroups, MockGroups>();
            services.AddScoped<IGroupMembers, MockGroupMembers>();
            services.AddScoped<IPayeeExpenses, MockPayeesExpenses>();
            services.AddScoped<IPayersExpenses, MockPayersExpenses>();
            services.AddScoped<ISettlement, MockSettlement>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
            {
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                    (resolver as DefaultContractResolver).NamingStrategy = null;

            });
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
