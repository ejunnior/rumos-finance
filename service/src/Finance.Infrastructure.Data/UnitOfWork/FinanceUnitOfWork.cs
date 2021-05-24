﻿namespace Finance.Infrastructure.Data.UnitOfWork
{
    using Domain.Core;
    using Mapping;
    using Microsoft.EntityFrameworkCore;

    public class FinanceUnitOfWork : DbContext
    {
        public void Commit()
        {
            base.SaveChanges();
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : AggregateRoot
        {
            base.Entry<TEntity>(item)
                .State = EntityState.Modified;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Data Source=(local);Initial Catalog=Db_FinanceRumos");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(CategoryMap).Assembly);
        }
    }
}