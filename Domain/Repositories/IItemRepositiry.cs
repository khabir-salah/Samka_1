

using System.Linq.Expressions;
using Domain.Aggregates.MarketPlaceAggregate.Entities;

namespace Domain.Repositories
{
    public interface IItemRepositiry
    {
        Task<Item> CreateItemAsync(Item item);
        Item UpdateItemAsync(Item item);
        bool DeleteItemAsync(Item item);
        Task<Item?> GetItemAsync(Expression<Func<Item, bool>> predicate);
        Task<bool> IsExistAsync(Expression<Func<Item, bool>> predicate);
        Task<IEnumerable<Item>> GetAllItemsAsync();
    }
}
