using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Transaction
{
    public class TransactionRepository : GenericRepository<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(DbContext context)
            : base(context)
        {
        }

        public TransactionEntity GetSingle(Guid idTransaction)
        {
            return Dbset.FirstOrDefault(x => x.IdTransaction == idTransaction);
        }

        public IEnumerable<TransactionEntity> GetAll(Guid idShipment)
        {
            return Dbset.Where(x => x.IdShipment == idShipment);
        }
    }
}
