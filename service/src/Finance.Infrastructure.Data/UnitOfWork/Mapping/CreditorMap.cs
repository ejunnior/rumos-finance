namespace Finance.Infrastructure.Data.UnitOfWork.Mapping
{
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CreditorMap : IEntityTypeConfiguration<Creditor>
    {
        public void Configure(EntityTypeBuilder<Creditor> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.CreditorName)
                .HasConversion(p => p.Value,
                    p => CreditorName.Create(p).Value)
                .HasMaxLength(80)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}