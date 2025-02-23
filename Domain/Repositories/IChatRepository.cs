

using System.Linq.Expressions;
using Domain.Aggregates.ChatAggregate.Entities;

namespace Domain.Repositories
{
    public interface IChatRepository
    {
        Task<Chat> CreateChatAsync(Chat chat);
        bool DeleteChatAsync(Chat chat);
        Task<bool> IsExistAsync(Expression<Func<Chat, bool>> predicate);
        Task<Chat?> GetChatAsync(Expression<Func<Chat, bool>> predicate);
        Task<IEnumerable<Chat>> GetAllChat();
    }
}
