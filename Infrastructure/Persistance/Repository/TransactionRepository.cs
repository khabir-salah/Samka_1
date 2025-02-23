using System.Linq.Expressions;
using Domain.Aggregates.PaymentAggregate.Entities;
using Domain.Repositories;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository
{
    public class TransactionRepository(SamkaDBContext DbContext) : ITransactionRepository
    {
        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            await DbContext.transactions.AddAsync(transaction);
            return transaction;
        }

        public bool DeleteTransactionAsync(Transaction transaction)
        {
            DbContext.transactions.Remove(transaction);
            return true;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            var getAllTransactions = await DbContext.transactions.ToListAsync();
            return getAllTransactions;
        }

        public async Task<Transaction?> GetTransactionAsync(Expression<Func<Transaction, bool>> predicate)
        {
            var getTransaction = await DbContext.transactions.FirstOrDefaultAsync(predicate);
            return getTransaction;
        }

        public async Task<bool> IsTransactionExistAsync(Expression<Func<Transaction, bool>> predicate)
        {
            var getExistTransaction = await DbContext.transactions.AnyAsync();
            return getExistTransaction;
        }

        public Transaction UpdateTransactionAsync(Transaction transaction)
        {
            DbContext.transactions.Update(transaction);
            return transaction;
        }
    }
}
