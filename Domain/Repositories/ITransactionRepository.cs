

using System.Linq.Expressions;
using Domain.Aggregates.PaymentAggregate.Entities;
namespace Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Transaction UpdateTransactionAsync(Transaction transaction);
        bool DeleteTransactionAsync(Transaction transaction);
        Task<Transaction?> GetTransactionAsync(Expression<Func<Transaction, bool>> predicate);
        Task<bool> IsTransactionExistAsync(Expression<Func<Transaction, bool>> predicate);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    }
}
