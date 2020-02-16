using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQRS.Mediatr.Sample.Application;
using SQRS.Mediatr.Sample.DAL;
using SQRS.Mediatr.Sample.Infrastructure;
using DiInfraType = SQRS.Mediatr.Sample.Infrastructure.DependencyInjection;
using DiApplicationType = SQRS.Mediatr.Sample.Application.DependencyInjection;

namespace AspNetCore.SQRS.Mediatr.Sample
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
            services.AddApplication(Configuration);
            services.AddDatabase(Configuration);
            services.AddSwagger(typeof(DiInfraType).Assembly);
            services.AddMapper(typeof(DiInfraType).Assembly, typeof(DiApplicationType).Assembly);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            context.Database.Migrate();

            app.AddErroHanldingMiddleWare();

            app.UseSwagger(Configuration);
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
