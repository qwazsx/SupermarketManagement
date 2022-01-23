using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IGetTransactionsByDayUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}