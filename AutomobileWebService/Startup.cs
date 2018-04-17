using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Repositories;
using AutomobileWebService.Business_Logic.Repositories.DAL;
using AutomobileWebService.Business_Logic.Repositories.Interfaces;
using AutomobileWebService.Framework;
using AutomobileWebService.Services;
using AutomobileWebService.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using React.AspNet;

namespace AutomobileWebService
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddReact();

            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);

            #region DatabaseConnection

            var connection = @"Server=(LocalDb)\MSSQLLocalDB;Initial Catalog=Automobile;Integrated Security=True;Trusted_Connection=True;";
            services.AddDbContext<AutomobileContext>(options => options.UseSqlServer(connection));

            #endregion

            #region IoC

            #region Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Repositories

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            #endregion

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            #region React

            // app.UseReact(config =>
            // {
            //     config
            //         .SetLoadBabel(false)
            //         .AddScriptWithoutTransform("~/Scripts/bundle.server.js");
            // });

            #endregion

            app.UseStaticFiles();
            app.UseErrorHandler();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults : new { controller = "Home", action = "Index" });
            });
        }
    }
}