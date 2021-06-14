using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewMovieAPI.Data;
using NewMovieAPI.Repository;
using NewMovieAPI.Repository.Interfaces;
using NewMovieAPI.Service;
using NewMovieAPI.Service.Interfaces;

namespace NewMovieAPI
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
            services.AddCors(c => c.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin()));

            services.AddControllers();
            // db context
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:MovieConnection"]));
            // *** Repositories
            services.AddTransient<IMovieRepository, MovieRepository>();
            // *** Services
            services.AddTransient<IMovieService, MovieService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
