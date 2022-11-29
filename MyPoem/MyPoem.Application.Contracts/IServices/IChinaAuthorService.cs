using MyPoem.Application.Contracts.Dtos.ChinaAuthor;
using MyPoem.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyPoem.Application.Contracts.IServices
{
    public interface IChinaAuthorService:IApplicationService
    {
        Task<ApiResult<long>> CountAsync();
        Task<ApiResult<PagedResultDto<ChinaAuthorDto>>> GetPagedListAsync(int skipCount, int maxResultCount);
    }
}
