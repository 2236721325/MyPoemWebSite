using Volo.Abp.Domain.Entities;

namespace MyPoem.Domain.Models
{
    public class ChinaPoem : BasicAggregateRoot<Guid>
    {

        public string Title { get; set; }
        public Guid ChinaAuthorId { get; set; }
        public ChinaAuthor ChinaAuthor { get; set; }
        /// <summary>
        /// 总的内容用json存储
        /// </summary>
        public string ParagraphsJSON { get; set; }
        public ChinaPoem(Guid id, Guid chinaAuthorId,string title, string paragraphsJSON)
        {
            Id = id;
            Title = title;
            ChinaAuthorId = chinaAuthorId;
            ParagraphsJSON = paragraphsJSON;
        }
    }

}
