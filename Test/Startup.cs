using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Test.Models;
using Newtonsoft.Json;

using Microsoft.Extensions.Configuration;

namespace Test
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
           
            string connection = Configuration.GetConnectionString("BloggingDatabase");
            // устанавливаем контекст данных
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));

            services.AddControllers(); // используем контроллеры без представлений
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "index.html");
            });
       
        }
    }
}