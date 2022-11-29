using MyPoem.Application.Contracts.Dtos.ChinaPoem;
using MyPoem.Application.Contracts.IServices;
using MyPoem.Domain.Models;
using MyPoem.Domain.Shared;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Text.Json;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace MyPoem.Application.Services
{
    public class ChinaPoemService : ApplicationService, IChinaPoemService
    {

        private readonly IRepository<ChinaPoem, Guid> _IPoemRepository;

        public ChinaPoemService(IRepository<ChinaPoem, Guid> iPoemRepository)
        {
            _IPoemRepository = iPoemRepository;
        }

        public async Task<ApiResult<long>> CountAsync()
        {
            var totalCount = await _IPoemRepository.LongCountAsync();
            return ApiResult.Ok(totalCount);
        }
        public async Task<ApiResult<ChinaPoemDetailDto>> GetAsync(Guid id)
        {
            var poem = await _IPoemRepository.GetAsync(id, true);
            if(poem == null)
            {
                return ApiResult.OhNo<ChinaPoemDetailDto>("id不存在");
            }
            var dto = new ChinaPoemDetailDto()
            {
                Id = poem.Id,
                ChinaAuthorName = poem.ChinaAuthor.Name,
                Title = poem.Title,
                Paragraphs = JsonSerializer.Deserialize<List<string>>(poem.ParagraphsJSON)
            };
            return ApiResult.Ok(dto);
        }

        

        public async Task<ApiResult<long>> CountAsync(Guid authorId)
        {
            var totalCount  = await _IPoemRepository.LongCountAsync(e => e.ChinaAuthorId == authorId);
            return ApiResult.Ok(totalCount);
        }

        public async Task<ApiResult<PagedResultDto<ChinaPoemSimpleDto>>> GetPagedListAsync(int skipCount, int maxResultCount)
        {
            var query = await _IPoemRepository.GetPagedListAsync(skipCount, maxResultCount, "Id", true);
            var result = ObjectMapper.Map<List<ChinaPoem>, List<ChinaPoemSimpleDto>>(query);
            return new ApiResult<PagedResultDto<ChinaPoemSimpleDto>>()
            {
                Status = true,
                Result = new PagedResultDto<ChinaPoemSimpleDto>(await _IPoemRepository.CountAsync(), result)
            };
        }
        public async Task<ApiResult<PagedResultDto<ChinaPoemSimpleDto>>> SearchPagedListAsync(string? poemName ,int skipCount, int maxResultCount)
        {
            var query = await _IPoemRepository.WithDetailsAsync();
            if(poemName!=null)
            {
                query = query.Where(e => e.Title.Contains(poemName));
            }
            var count = query.Count();
            var list = query.PageBy(skipCount, maxResultCount).ToList();
            var result = ObjectMapper.Map<List<ChinaPoem>, List<ChinaPoemSimpleDto>>(list);
            return new ApiResult<PagedResultDto<ChinaPoemSimpleDto>>()
            {
                Status = true,
                Result = new PagedResultDto<ChinaPoemSimpleDto>(count, result)
            };
        }

        public async Task<ApiResult<PagedResultDto<ChinaPoemSimpleDto>>> GetPagedListAsync(Guid authorId, int skipCount, int maxResultCount)
        {
            var query = await _IPoemRepository.WithDetailsAsync();
            query = query
                .Where(e => e.ChinaAuthorId == authorId);
            var count = query.Count();
            var result = query.PageBy(skipCount, maxResultCount)
                             .ToList();
            var dto = ObjectMapper.Map<List<ChinaPoem>, List<ChinaPoemSimpleDto>>(result);

            return ApiResult.Ok(new PagedResultDto<ChinaPoemSimpleDto>(count, dto));
        }
    }
}
