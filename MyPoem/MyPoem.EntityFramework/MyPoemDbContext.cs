using MyPoem.Domain.Models;
using Microsoft.EntityFrameworkCore;

using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MyPoem.EntityFramework
{
    [ConnectionStringName("Default")]
    public class MyPoemDbContext : AbpDbContext<MyPoemDbContext>
    {
        public DbSet<ChinaPoem> ChinaPoems { get; set; }
        public DbSet<ChinaAuthor> ChinaAuthors { get; set; }

        public MyPoemDbContext(DbContextOptions<MyPoemDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
