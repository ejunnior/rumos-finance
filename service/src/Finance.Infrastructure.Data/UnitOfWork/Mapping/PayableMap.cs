namespace Finance.Infrastructure.Data.UnitOfWork.Mapping
{
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Category.Aggregates.CategoryAggregate;
    using Domain.Creditor.Aggregates.CreditorAggregate;
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
                .IsRequired()
                .HasColumnType("decimal(7,2)");

            builder
                .Property(p => p.Description)
                .HasConversion(p => p.Value,
                    p => Description.Create(p).Value)
                .HasMaxLength(80)
                .HasColumnType("varchar")
                .IsRequired();

            builder
                .Property(p => p.DocumentDate)
                .HasConversion(p => p.Value,
                    p => DocumentDate.Create(p).Value)
                .IsRequired();

            builder
                .Property(p => p.DocumentNumber)
                .HasConversion(p => p.Value,
                    p => DocumentNumber.Create(p).Value)
                .HasMaxLength(20)
                .HasColumnType("varchar")
                .IsRequired();

            builder
                .Property(p => p.DueDate)
                .HasConversion(p => p.Value,
                    p => DueDate.Create(p).Value)
                .IsRequired();

            builder
                .Property(p => p.PaymentDate)
                .HasConversion(p => p.Value,
                    p => PaymentDate.Create(p).Value)
                .IsRequired();

            //Relacionamentos - FK
            builder
                .HasOne<Category>(p => p.Category);

            builder
                .HasOne<Creditor>(p => p.Creditor);

            builder
                .HasOne<BankAccount>(p => p.BankAccount);
        }
    }
}