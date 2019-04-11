using BaseJWT.API.Middleware;
using BaseJWT.API.Services;
using BaseJWT.Infrastructure.EntityFramework.Context;
using BaseJWT.Infrastructure.EntityFramework.Seeder;
using BaseJWT.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseJWT
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        readonly AppServiceSetup appServiceSetup;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            appServiceSetup = new AppServiceSetup();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            });

            appServiceSetup.Set(services, Configuration);

            IdentityTokenSetup.Set(services, Configuration);

            services.AddTransient<Seeder>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

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

            app.UseAuthorizationPatch();
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
