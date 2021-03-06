﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.FileProviders;
//using Microsoft.Owin;

using Microsoft.EntityFrameworkCore;
using capstone.Models;

namespace capstone
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

			services.AddDbContext<StudentContext>(options =>
		        options.UseSqlite("Data Source=findAMentor.db"));
			services.AddDbContext<MentorContext>(options =>
				options.UseSqlite("Data Source=findAMentor.db"));
			services.AddDbContext<SubjectContext>(options =>
				options.UseSqlite("Data Source=findAMentor.db"));
            services.AddDbContext<MentorSubjectsContext>(options =>
				options.UseSqlite("Data Source=findAMentor.db"));
			services.AddDbContext<StudentSubjectsContext>(options =>
				options.UseSqlite("Data Source=findAMentor.db"));
            services.AddDbContext<StudentClassesViewModelContext>(options =>
	            options.UseSqlite("Data Source=findAMentor.db"));

		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DBinitialize.EnsureCreated(app.ApplicationServices);
            SeedData.Initialize(app.ApplicationServices);
        }
    }
}
