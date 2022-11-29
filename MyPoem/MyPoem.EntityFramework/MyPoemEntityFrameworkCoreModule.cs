using MyPoem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using MyPoem.Domain.Models;

namespace MyPoem.EntityFramework
{
    [DependsOn(
     typeof(MyPoemDomainModule)
     )]
    [DependsOn(
    typeof(AbpEntityFrameworkCoreMySQLModule)
     )]
    [DependsOn(
    typeof(AbpEntityFrameworkCoreModule)
     )]
    public class MyPoemEntityFrameworkCoreModule : AbpModule
    {


        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MyPoemDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });
            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also LearnAbpMigrationsDbContextFactory for EF Core tooling. */
                options.UseMySQL();
            });
            Configure<AbpEntityOptions>(options =>
            {
                options.Entity<ChinaPoem>(orderOptions =>
                {
                    orderOptions.DefaultWithDetailsFunc = query => query.Include(o => o.ChinaAuthor);
                });
                options.Entity<ChinaAuthor>(orderOptions =>
                {
                    orderOptions.DefaultWithDetailsFunc = query => query.Include(o => o.ChinaPoems);
                });
            });

        }
    }
}