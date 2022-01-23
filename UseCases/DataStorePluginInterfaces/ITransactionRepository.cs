using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions(string cashierName);
        IEnumerable<Transaction> GetByDay(string cashierName, DateTime day);
        IEnumerable<Transaction> GetByDateRange(string cashierName, DateTime startDate, DateTime endDate);
        void Save(string cashierName, int productId, string productName, double price, int beforeQuantity, int soldQuantity);
    }
}
