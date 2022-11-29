using Microsoft.Extensions.Options;
using MyPoem.Application.Contracts.Dtos.ChinaAuthor;
using MyPoem.Application.Contracts.IServices;
using MyPoem.Domain.Models;
using MyPoem.Domain.Shared;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace MyPoem.Application.Services
{

    public class ChinaAuthorService : ApplicationService, IChinaAuthorService
    {
        private readonly IRepository<ChinaAuthor, Guid> _AuthorRepository;
        private readonly IGuidGenerator _GuidGenerator;

        public ChinaAuthorService(IGuidGenerator guidGenerator, IRepository<ChinaAuthor, Guid> authorRepository)
        {
            _GuidGenerator = guidGenerator;
            _AuthorRepository = authorRepository;
        }
        public async Task<ApiResult<long>> CountAsync()
        {
            var count = await _AuthorRepository.LongCountAsync();
            return ApiResult.Ok<long>(count);
        }
        public async Task<ApiResult<ChinaAuthorDto>> GetAsync(Guid id)
        {
            var result =await _AuthorRepository.GetAsync(id);
            if (result == null) return ApiResult.OhNo<ChinaAuthorDto>("id不存在");
            var dto= ObjectMapper.Map<ChinaAuthor, ChinaAuthorDto>(result);
            return ApiResult.Ok(dto);
        }
        public async Task<ApiResult<PagedResultDto<ChinaAuthorDto>>> SearchPagedListAsync(string? poetName,int skipCount, int maxResultCount)
        {
            var query = await _AuthorRepository.GetQueryableAsync();
            if (poetName != null)
            {
                query = query.Where(e => e.Name.Contains(poetName));
            }
            var count = query.Count();
            var list = query.PageBy(skipCount, maxResultCount).ToList();
            var result = ObjectMapper.Map<List<ChinaAuthor>, List<ChinaAuthorDto>>(list);
            return new ApiResult<PagedResultDto<ChinaAuthorDto>>()
            {
                Status = true,
                Result = new PagedResultDto<ChinaAuthorDto>(count, result)
            };
        }
        public async Task<ApiResult<PagedResultDto<ChinaAuthorDto>>> GetPagedListAsync(int skipCount, int maxResultCount)
        {
            var result = ObjectMapper.Map<List<ChinaAuthor>, List<ChinaAuthorDto>>(await _AuthorRepository.GetPagedListAsync(skipCount, maxResultCount, "Id"));
            return new ApiResult<PagedResultDto<ChinaAuthorDto>>()
            {
                Status = true,
                Result = new PagedResultDto<ChinaAuthorDto>(await _AuthorRepository.CountAsync(), result)
            };
        }








        //public async Task<ApiResult> CreateAllAuthor()
        //{
        //    string filepath = "D:\\Datas\\modern-poetry-master\\China-modern-poetry\\contemporary\\author.json";
        //    string json = string.Empty;
        //    using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
        //    {
        //        using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
        //        {
        //            json = sr.ReadToEnd().ToString();
        //        }
        //    }
        //    var authors = JsonSerializer.Deserialize<author[]>(json);
        //    int ks = 1;
        //    foreach (var item in authors)
        //    {
        //        var chinaAuthor = new ChinaAuthor(_GuidGenerator.Create(), item.name,item.description, PeriodType.Modern);
        //        await _AuthorRepository.InsertAsync(chinaAuthor, true);

        //        Console.WriteLine(ks++);
        //    }
        //    return new ApiResult()
        //    {
        //        Status = true
        //    };
        //}
        //public async Task<ApiResult> CreateAllPoem()
        //{
        //    try
        //    {
        //        var files = (Directory.GetFiles("D:\\Datas\\modern-poetry-master\\China-modern-poetry\\contemporary"));
        //        foreach (var file in files)
        //        {
        //            string json = string.Empty;
        //            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
        //            {
        //                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
        //                {
        //                    json = sr.ReadToEnd().ToString();
        //                }
        //            }
        //            var poems = JsonSerializer.Deserialize<poem[]>(json);
        //            foreach (var item in poems)
        //            {

        //                var author = await _AuthorRepository.FindAsync(e => e.Name == item.author);
        //                Console.WriteLine(author.Id);


        //                var chinaPoem = new ChinaPoem(_GuidGenerator.Create(), author.Id, item.title, JsonSerializer.Serialize(item.paragraphs));
        //                await _PoemRepository.InsertAsync(chinaPoem, true);
        //                Console.WriteLine(item.author);
        //            }
        //        }

        //        return new ApiResult()
        //        {
        //            Status = true
        //        };
        //    }

        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //        return new ApiResult()
        //        { 
        //        Status=true
        //        };

        //    }
        //}

    }
}
