using AutoMapper;
using MyPoem.Application.Contracts.Dtos.ChinaAuthor;
using MyPoem.Application.Contracts.Dtos.ChinaPoem;
using MyPoem.Domain.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace MyPoem.Application
{
    public class MyPoemApplicationAutoMapperProfile : Profile
    {
        public MyPoemApplicationAutoMapperProfile()
        {
            CreateMap<ChinaAuthor, ChinaAuthorDto>();
            CreateMap<ChinaPoem, ChinaPoemSimpleDto>().ForMember(d => d.ChinaAuthorName, f => f.MapFrom(e => e.ChinaAuthor.Name));
            CreateMap<ChinaPoem, ChinaPoemDetailDto>()
                .ForMember(d => d.ChinaAuthorName, f => f.MapFrom(e => e.ChinaAuthor.Name))
                .ForMember(d => d.Paragraphs, f => f.MapFrom(e => MyDeseralize(e.ParagraphsJSON)));


        }
        public static List<string>? MyDeseralize(string json)
        {
            return JsonSerializer.Deserialize<List<string>>(json);
        }
    }
}