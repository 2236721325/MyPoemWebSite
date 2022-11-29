using MyPoem.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MyPoem.Application.Contracts.Dtos.ChinaAuthor
{
    public class ChinaAuthorDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string? Discriptions { get; set; }
        public PeriodType PeriodType { get; set; }
    }
}
