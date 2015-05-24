using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;

namespace BaLogisticsSystem.Service.Transaction
{
    public interface ITransactionService
    {
        TransactionEntity GetSingle(Guid idTransaction);
        IEnumerable<TransactionEntity> GetList();
        IEnumerable<TransactionEntity> GetList(Guid idTransaction);
    }
}
