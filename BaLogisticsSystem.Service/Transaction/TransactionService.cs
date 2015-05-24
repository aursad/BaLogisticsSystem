using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;
using BaLogisticsSystem.Repository.Transaction;
using BaLogisticsSystem.Service.Common;

namespace BaLogisticsSystem.Service.Transaction
{
    public class TransactionService : EntityService<TransactionEntity>, ITransactionService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ITransactionRepository _transactionRepository;

        public TransactionService(IUnitOfWork unitOfWork, ITransactionRepository transactionRepository)
            : base(unitOfWork, transactionRepository)
        {
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
        }


        public TransactionEntity GetSingle(Guid idTransaction)
        {
            return _transactionRepository.GetSingle(idTransaction);
        }

        public IEnumerable<TransactionEntity> GetList()
        {
            return _transactionRepository.GetAll();
        }

        public IEnumerable<TransactionEntity> GetList(Guid idTransaction)
        {
            return _transactionRepository.GetAll(idTransaction);
        }
    }
}
