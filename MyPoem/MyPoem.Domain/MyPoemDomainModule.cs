
using MyPoem.Domain.Shared;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace MyPoem.Domain
{
    [DependsOn(
     typeof(MyPoemDomainSharedModule),
     typeof(AbpDddDomainModule)
 )]
    public class MyPoemDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}