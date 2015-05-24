using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Transaction
{
    public interface ITransactionRepository : IGenericRepository<TransactionEntity>
    {
        TransactionEntity GetSingle(Guid idTransaction);
        IEnumerable<TransactionEntity> GetAll(Guid idShipment);
    }
}
