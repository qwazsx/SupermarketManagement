using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        public List<Transaction> transactions;
        public TransactionInMemoryRepository()
        {
            transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> GetByDateRange(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
            }
            else
            {
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date && string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime day)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return transactions.Where(x => x.TimeStamp.Date == day.Date);
            }
            else
            {
                return transactions.Where(x => x.TimeStamp.Date == day.Date && string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public IEnumerable<Transaction> GetTransactions(string cashierName)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return transactions;
            }
            else
            {
                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQuantity, int soldQuantity)
        {
            int transactionId = 0;
            if (transactions != null && transactions.Count > 0)
            {
                int maxId = transactions.Max(x => x.TransactionId);
                transactionId = maxId + 1;
            }
            else
            {
                transactionId = 1;
            }

            transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQuantity = beforeQuantity,
                SoldQuantity = soldQuantity,
                CashierName = cashierName
            });
        }
    }
}
