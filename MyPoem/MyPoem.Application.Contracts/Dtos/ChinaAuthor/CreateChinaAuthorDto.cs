using MyPoem.Domain.Shared;

namespace MyPoem.Application.Contracts.Dtos.ChinaAuthor
{
    public class CreateChinaAuthorDto
    {
        public string Name { get; set; }
        public string? Discriptions { get; set; }
        public PeriodType PeriodType { get; set; }
    }
}
