using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dapper_Tutorial_Project
{
    public class InternalOptions
    {
        public string ConnectionString { get; set; }
    }
    public class Startup
    {
        public const string AllowLocalhost = "_allowLocalhost";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowLocalhost,
                builder =>
                {
                    builder.WithOrigins("http://localhost:5500",
                                        "http://127.0.0.1:5500",
                                        "https://localhost:5500",
                                        "https://127.0.0.1:5500");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<InternalOptions>(options =>
                options.ConnectionString = Configuration.GetConnectionString("AttendeeDemo"));
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(AllowLocalhost);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
