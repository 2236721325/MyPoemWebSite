using MyPoem.Domain.Shared;
using Volo.Abp.Modularity;

namespace MyPoem.Application.Contracts
{
    [DependsOn(
    typeof(MyPoemDomainSharedModule)
    )]
    public class MyPoemApplicationContractsModule : AbpModule
    {

    }
}