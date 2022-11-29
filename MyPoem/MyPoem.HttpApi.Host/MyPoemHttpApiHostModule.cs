using Microsoft.OpenApi.Models;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp;
using MyPoem.Application;
using MyPoem.EntityFramework;

namespace MyPoem.HttpApi.Host
{
    [DependsOn(
     typeof(AbpAutofacModule),
     typeof(MyPoemApplicationModule),
     typeof(MyPoemEntityFrameworkCoreModule),
     typeof(AbpSwashbuckleModule),
     typeof(AbpAspNetCoreMvcModule)
)]
    public class MyPoemHttpApiHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            ConfigureSwaggerGen(context);
            ConfigureConventionalControllers();
            context.Services.AddCors(c =>
            {
                c.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

        }

        private void ConfigureSwaggerGen(ServiceConfigurationContext context)
        {
            context.Services.AddAbpSwaggerGen(
                  options =>
                  {
                      options.SwaggerDoc("v1", new OpenApiInfo { Title = "MyPoem", Version = "v1" });
                      options.DocInclusionPredicate((docName, description) => true);
                  }
              );
        }

        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(MyPoemApplicationModule).Assembly);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            app.UseCors("AllowAllOrigins");
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyPoem");
            });
            app.UseRouting();
            app.UseStaticFiles();
            app.UseConfiguredEndpoints();
        }
      
    }
}