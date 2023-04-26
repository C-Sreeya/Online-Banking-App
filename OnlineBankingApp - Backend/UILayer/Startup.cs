using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DALayer;
using DALayer.Models;

namespace UILayer
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
            services.AddMvc();
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors();
            services.AddTransient(typeof(OnlineBankingSystemDbContext));
            services.AddTransient(typeof(LoginDataService));
            services.AddTransient(typeof(ILogin),typeof(LoginDataService));
            services.AddTransient(typeof(AccountDataService));
            services.AddTransient(typeof(IAccount),typeof(AccountDataService));
            services.AddTransient(typeof(AccountDetailsDataService));
            services.AddTransient(typeof(IAccountDetails), typeof(AccountDetailsDataService));
            services.AddTransient(typeof(LoanDataService));
            services.AddTransient(typeof(ILoan), typeof(LoanDataService));
            services.AddTransient(typeof(TransactionDataService));
            services.AddTransient(typeof(ITransaction), typeof(TransactionDataService));

            services.AddSwaggerGen();

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

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
