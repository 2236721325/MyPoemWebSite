using MyPoem.Application.Contracts;
using MyPoem.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace MyPoem.Application
{
    [DependsOn(
    typeof(MyPoemDomainModule),
    typeof(MyPoemApplicationContractsModule),
    typeof(AbpAutoMapperModule)
    )]
    public class MyPoemApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
          
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MyPoemApplicationModule>();
            });
            Configure<AbpSequentialGuidGeneratorOptions>(options =>
            {
                options.DefaultSequentialGuidType = SequentialGuidType.SequentialAsString;
            });
        }
    }
}