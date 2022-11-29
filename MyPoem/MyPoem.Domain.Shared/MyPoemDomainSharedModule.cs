using Volo.Abp.Modularity;
using Volo.Abp.Validation;

namespace MyPoem.Domain.Shared
{
    [DependsOn(
          typeof(AbpValidationModule)
     )]
    public class MyPoemDomainSharedModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}