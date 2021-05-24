namespace Finance.Infrastructure.Data.UnitOfWork.Mapping
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.CategoryName)
                .HasConversion(p => p.Value,
                    p => CategoryName.Create(p).Value)
                .HasMaxLength(80)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}