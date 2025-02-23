

using System.Linq.Expressions;
using Domain.Aggregates.ChatAggregate.Entities;
using Domain.Repositories;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository
{
    public class ChatRepository(SamkaDBContext DBcontext) : IChatRepository
    {
        public async Task<Chat> CreateChatAsync(Chat chat)
        {
            await DBcontext.chats.AddAsync(chat);
            return chat;
        }

        public bool DeleteChatAsync(Chat chat)
        {
            DBcontext.chats.Remove(chat);
            return true;
        }

        public async Task<IEnumerable<Chat>> GetAllChat()
        {
            var getAllChats = await DBcontext.chats.ToListAsync();
            return getAllChats;
        }

        public async Task<Chat?> GetChatAsync(Expression<Func<Chat, bool>> predicate)
        {
            var getChat = await DBcontext.chats.FirstOrDefaultAsync(predicate);
            return getChat;
        }

        

        public async Task<bool> IsExistAsync(Expression<Func<Chat, bool>> predicate)
        {
            return await DBcontext.chats.AnyAsync(predicate);
        }
    }
}
