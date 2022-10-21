using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PublicHolidays.Core;
using PublicHolidays.Core.Services;
using PublicHolidays.Data;
using PublicHolidays.Services;
using System;

namespace PublicHolidays.Api
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
            services.AddControllers();

            services.AddDbContext<PublicHolidaysDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("PublicHolidays.Data"));
            });
            services.AddSwaggerDocument(configure => configure.Title = "Public Holidays API");

            services.AddHttpClient("PublicHolidaysApi", c => c.BaseAddress = new Uri("https://kayaposoft.com"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IHolidayService, HolidayService>();
            services.AddTransient<ICountryService, CountryService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

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
