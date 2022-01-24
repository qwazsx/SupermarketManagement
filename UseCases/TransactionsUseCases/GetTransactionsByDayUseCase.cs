﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetTransactionsByDayUseCase : IGetTransactionsByDayUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTransactionsByDayUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return transactionRepository.GetByDay(cashierName, DateTime.Now);
        }
    }
}