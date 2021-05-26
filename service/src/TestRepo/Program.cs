using System;

namespace TestRepo
{
    using Finance.Domain.Creditor.Aggregates.CreditorAggregate;
    using Finance.Infrastructure.Data.Creditor.Repository;
    using Finance.Infrastructure.Data.UnitOfWork;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Digite o nome da Categoria:");

            var input = Console.ReadLine();

            var creditorName = CreditorName.Create(input);

            if (creditorName.IsSuccess)
            {
                var creditor = new Creditor(creditorName.Value);

                var unitOfWork = new FinanceUnitOfWork();

                var creditorRepo = new CreditorRepository(unitOfWork);

                creditorRepo.Add(creditor);

                unitOfWork.Commit();
            }
            else
            {
                Console.WriteLine(creditorName.Error);
            }

            Console.ReadKey();
        }
    }
}