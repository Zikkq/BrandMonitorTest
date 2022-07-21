using BrandMonitorTest.Infrastructure;
using Microsoft.EntityFrameworkCore;
using BrandMonitorTest.Data;

namespace BrandMonitorTest
{
    public sealed class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<Context>(x => x.UseNpgsql(_config.GetConnectionString("DefaultConnection")));
            services.AddScoped<TaskRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}