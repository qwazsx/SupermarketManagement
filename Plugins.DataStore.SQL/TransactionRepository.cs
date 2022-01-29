using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionRepository(MarketContext db)
        {
            this.db = db;
        }
        public IEnumerable<Transaction> GetByDateRange(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return db.Transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
            }
            else
            {
                return db.Transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date && string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime day)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date == day.Date);
            }
            else
            {
                return db.Transactions.Where(x => x.TimeStamp.Date == day.Date && string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public IEnumerable<Transaction> GetTransactions(string cashierName)
        {
            return db.Transactions.ToList();
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQuantity, int soldQuantity)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQuantity = beforeQuantity,
                SoldQuantity = soldQuantity,
                CashierName = cashierName
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}
