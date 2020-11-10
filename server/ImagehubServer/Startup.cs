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
using System;

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

            services.AddHttpContextAccessor();
            services.AddControllers();

            services.AddAutoMapper(typeof(ImageHubProfile));

            // repos --> scoped lifecycle for db access
            services.AddScoped<ICrudRepository<ImagehubImage>, ImageRepository>();
            services.AddScoped<ICrudRepository<Friend>, FriendRepository>();
            services.AddScoped<ICrudRepository<FriendRequest>, FriendRequestRepository>();

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAuthService, IdentityAuthService>();
            services.AddScoped<IFriendService, FriendService>();

            services.AddAuthentication(opts =>
            {
                // identity authentication options
                opts.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                opts.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                opts.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            });

            // identity authentication config
            //based on: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.SlidingExpiration = true;
            });

            services.AddCors(c =>
            {
                c.AddPolicy("img", options => {
                    options
                        .WithOrigins("localhost")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
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
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseCors("img");

            app.UseAuthorization();

            app.UseEndpoints(endpts =>
            {
                endpts.MapControllers();
            });
        }
    }
}
