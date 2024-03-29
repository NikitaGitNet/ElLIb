using ElLIb.Domain;
using ElLIb.Domain.Entities;
using ElLIb.Domain.Interfaces;
using ElLIb.Domain.Repository;
using ElLIb.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElLIb
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            services.AddHttpContextAccessor();
            services.AddTransient<IRepository<TextField>, EFTextFieldsRepository>();
            services.AddTransient<IRepository<Book>, EFBooksRepository>();
            services.AddTransient<IRepository<Comment>, EFCommentsRepository>();
            services.AddTransient<IRepository<Booking>, EFBookingsRepository>();
            services.AddTransient<IRepository<ApplicationUser>, EFApplicationUserRepository>();
            services.AddTransient<IRepository<Genre>, EFGenresRepository>();
            services.AddTransient<IRepository<Author>, EFAuthorsRepository>();

            //��� ����������� � PostgreSQL
            services.AddDbContext<AppDbContext>(x => x.UseNpgsql(Config.ConnectionString));
            //��� ����������� � MS SQL
            //services.AddDbContext<AppDbContext>(x=>x.UseSqlServer(Config.ConnectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(x =>
                {
                    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
                    x.AddPolicy("ModeratorArea", policy => { policy.RequireRole("moderator"); });
                });

            services.AddControllersWithViews(x =>
                {
                    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
                    x.Conventions.Add(new ModeratorAreaAuthorization("Moderator", "ModeratorArea"));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("moderator", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
