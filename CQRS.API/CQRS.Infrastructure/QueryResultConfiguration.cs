using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Infrastructure
{
    public class QueryResultConfiguration : IEntityTypeConfiguration<QueryResult>
    {
        public void Configure(EntityTypeBuilder<QueryResult> builder)
        {
            builder.HasNoKey();
        }
    }
}
