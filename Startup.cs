
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinistryOfJustice.Models;
using MinistryOfJustice.Models.DataManager;
using MinistryOfJustice.Models.Repository;
using MinistryOfJustice.Services;
using MinistryOfJustice.Settings;
using System.IO;

namespace MinistryOfJustice
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
            services.AddDbContext<MinistryOfJusticeContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:MinistryOfJusticeDB"]));
            services.AddScoped<IAssociationRepository, AssociationManager>();
            services.AddScoped<IAssociationTypeRepository, AssociationTypeManager>();
            services.AddScoped<ICurrencyTypeRepository, CurrencyTypeManager>();
            services.AddTransient<IMailService, MailService>();

            services.AddScoped<IAssociationService, AssociationService>();

            services.AddMvc(option => option.EnableEndpointRouting = true);
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAllOrigins",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
            services.AddControllers().AddNewtonsoftJson();
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "client-app/build";
            //});

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = Path.Join(env.ContentRootPath, "client-app");

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseReactDevelopmentServer(npmScript: "start");
            //    }
            //});

            // Handles exceptions and generates a custom response body
            app.UseExceptionHandler("/errors/500");

            // Handles non-success status codes with empty body
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
        }
    }
}
