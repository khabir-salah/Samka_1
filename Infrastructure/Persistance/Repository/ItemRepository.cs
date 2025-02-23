

using System.Linq.Expressions;
using Domain.Aggregates.MarketPlaceAggregate.Entities;
using Domain.Repositories;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository
{
    public class ItemRepository(SamkaDBContext DBcontext) : IItemRepositiry
    {
        public async Task<Item> CreateItemAsync(Item item)
        {
            await DBcontext.Items.AddAsync(item);
            return item;
        }

        public bool DeleteItemAsync(Item item)
        {
            DBcontext.Items.Remove(item);
            return true;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            var getItems = await DBcontext.Items.ToListAsync();
            return getItems;
        }

        public async Task<Item?> GetItemAsync(Expression<Func<Item, bool>> predicate)
        {
            var getItem = await DBcontext.Items.FirstOrDefaultAsync(predicate);
            return getItem;
        }

        public async Task<bool> IsExistAsync(Expression<Func<Item, bool>> predicate)
        {
            var isExist =await DBcontext.Items.AnyAsync(predicate);
            return isExist;
        }

        public Item UpdateItemAsync(Item item)
        {
            DBcontext.Items.Update(item);
            return item;
        }
    }
}
