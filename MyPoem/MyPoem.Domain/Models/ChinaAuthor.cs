using MyPoem.Domain.Shared;
using Volo.Abp.Domain.Entities;

namespace MyPoem.Domain.Models
{
    public class ChinaAuthor:BasicAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string? Discriptions { get; set; }
        public PeriodType PeriodType { get; set; }
        public List<ChinaPoem>? ChinaPoems { get; set; }
        public ChinaAuthor(Guid id,string name, string? discriptions, PeriodType periodType)
        {
            Id = id;
            Name = name;
            Discriptions = discriptions;
            PeriodType = periodType;
        }
    }
}
