namespace Finance.Infrastructure.Data.UnitOfWork.Mapping
{
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountMap : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.AccountNumber)
                .HasConversion(p => p.Value,
                    p => AccountNumber.Create(p).Value)
                .HasMaxLength(80)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}