namespace Finance.Infrastructure.Data.UnitOfWork
{
    using System.Threading.Tasks;
    using Domain.Core;
    using Mapping;
    using Microsoft.EntityFrameworkCore;

    public class FinanceUnitOfWork : DbContext, IFinanceUnitOfWork
    {
        public async Task CommitAsync()
        {
            await base
                .SaveChangesAsync();
        }

        public DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : AggregateRoot
        {
            return base
                .Set<TEntity>();
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : AggregateRoot
        {
            base.Entry<TEntity>(item)
                .State = EntityState.Modified;
        }

        //Forma de configurar a string de conexao
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Data Source=(local);Initial Catalog=Db_FinanceRumos");
        }

        //Configurar as classes de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(CategoryMap).Assembly);
        }
    }
}