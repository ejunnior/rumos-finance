namespace Finance.Infrastructure.Data.UnitOfWork.Mapping
{
    using Domain.Treasury.Aggregates.PayableAggregate;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PayableMap : IEntityTypeConfiguration<Payable>
    {
        public void Configure(EntityTypeBuilder<Payable> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Amount)
                .HasConversion(p => p.Value,
                    p => Amount.Create(p).Value)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasConversion(p => p.Value,
                    p => Description.Create(p).Value)
                .HasMaxLength(80)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}