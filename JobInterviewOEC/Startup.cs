using JobInterviewOEC.Configuration;
using JobInterviewOEC.DataAccess;
using JobInterviewOEC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobInterviewOEC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var connectionString = Configuration.GetConnectionString("AppDbContextConnectionString");
            services.AddDbContext<AppDbContext>(builder =>
            {
                builder.UseSqlServer(connectionString);
            });

            services.AddScoped<IAtlasDataRepository, AtlasDataRepository>();
            services.AddScoped<IAtlasFileConfiguration, AtlasFileConfiguration>();
            services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();
            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<IDataParser, DataParser>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var seeder = serviceScope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
                var atlasDataRepository = serviceScope.ServiceProvider.GetRequiredService<IAtlasDataRepository>();
                if (!atlasDataRepository.Any().GetAwaiter().GetResult())
                {
                    seeder.Seed().GetAwaiter().GetResult();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=AtlasData}/{action=Index}/{id?}");
            });
        }
    }
}
