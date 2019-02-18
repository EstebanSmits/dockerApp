using dockerApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dockerApp
{
    public class Startup
    {
        public Startup( IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<IConfiguration>(Configuration);
            if (Configuration.GetConnectionString("Books") == null) {
                 services.AddDbContext<BookDbContext>( options => options.UseInMemoryDatabase("Books"));
                 
             }
             else
             {
                 services.AddDbContext<BookDbContext>( options => options.UseSqlServer(Configuration.GetConnectionString("Books")) );
                // services.AddHealthChecks().AddSqlServer(Configuration.GetConnectionString("Books"));
             }
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            // if there is an actual database connection string, try to initiatlize database
            if(Configuration.GetConnectionString("Books") != null)
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        var dbContext = serviceScope.ServiceProvider.GetService<BookDbContext>();
                        dbContext.Database.EnsureCreated();
                        var sql = dbContext.Database.GenerateCreateScript();
                    }
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();
        }
    }
}
