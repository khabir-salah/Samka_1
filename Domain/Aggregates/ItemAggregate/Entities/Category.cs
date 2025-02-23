

using Domain.Sheared.Entities;

namespace Domain.Aggregates.MarketPlaceAggregate.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string Icon { get; private set; } = default!;
        public List<Item> Items { get; private set; } = new List<Item>();
        public IReadOnlyCollection<Item> Service => Items.AsReadOnly();

        public Category() { }

        public Category(string name, string description, string icon)
        {
            Name = name;
            Description = description;
            Icon = icon;
        }

        public void UpdateCategory(string name, string description, string icon)
        {
            Name = name ?? Name;
            Description = description
                ?? Description;
            Icon = icon ?? Icon;
        }

        public void DeleteItem(Guid itemId)
        {
            var service = Items.FirstOrDefault(i => i.Id == itemId);
            if (service != null)
            {
                Items.Remove(service);
            }
        }
    }
}
