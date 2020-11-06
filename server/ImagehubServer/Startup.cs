using AutoMapper;
using Data;
using Data.Models;
using Imagehub.Core.Mappings;
using Imagehub.Core.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Implementations;
using Repository.Interfaces;
using Services.Implementations;
using Services.Interfaces;

namespace ImagehubServer
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
            services.AddIdentity<ImageHubUser, UserRole>()
                .AddEntityFrameworkStores<ImageHubDbContext>();

            services.AddDbContext<ImageHubDbContext>(options =>
            {
                options.UseSqlServer("[CONN]");
            }, ServiceLifetime.Scoped);

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });


            services.AddControllers();

            services.AddAutoMapper(typeof(ImageHubProfile));

            // repos --> scoped lifecycle for db access
            services.AddScoped<ICrudRepository<ImagehubImage>, ImageRepository>();

            // services --> scoped lifecycle to avoid scoped-sigleton trap
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAuthService, IdentityAuthService>();

            services.AddCors(c =>
            {
                c.AddPolicy("img", options => {
                    //options.WithOrigins("[SOME ORIGIN LATER]");
                    options
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

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
                app.UseHsts();
            }

            app.ConfigureExceptionHandler();

            app.UseRouting();
            app.UseCors("img");
            app.UseEndpoints(endpts =>
            {
                endpts.MapControllers();
            });


        }
    }
}
