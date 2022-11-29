using Volo.Abp.Application.Dtos;

namespace MyPoem.Application.Contracts.Dtos.ChinaPoem
{
    public class ChinaPoemSimpleDto : EntityDto<Guid>
    {
        public string? Title { get; set; }
        public string? ChinaAuthorName { get; set; }
    }
}
