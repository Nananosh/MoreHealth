using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoreHealth.Business.Interfaces;
using MoreHealth.Business.Services;
using MoreHealth.Controllers;
using MoreHealth.Models;
using MoreHealth.ViewModels.Mappings;

namespace MoreHealth
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
            // var mappingConfig = new MapperConfiguration(mc =>
            // {
            //     mc.AddProfile(new UserMappingProfile());
            // });
            // IMapper mapper = mappingConfig.CreateMapper();
            // services.AddSingleton(mapper);
            
            services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddControllersWithViews();

            services.AddScoped<IFeedBackService, FeedBackService>();
            services.AddScoped<IDoctorOrPatientService, DoctorOrPatientService>();
            services.AddScoped<IPaidServicesService, PaidServicesService>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddDbContext<ApplicationContext>(
                options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"),
                        x => x.MigrationsAssembly("MoreHealth")));
            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                                                             "0123456789абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМН" +
                                                             "ОПРСТУФХЦЧШЩЪЫЬЭЮЯ_ ";
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationContext>();
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

            app.UseAuthentication();
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