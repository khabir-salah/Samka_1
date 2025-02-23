using Domain.Sheared.Entities;

namespace Domain.Aggregates.UserAggregate.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public List<User> Users { get; private set; } = new List<User>();

        #region Constructor
        private Role() { }

        public Role(string name)
        {
            Name = name;
        }
        #endregion

        public void AssignRole(string roleName, User user)
        {

            var newRole = new Role(roleName);
            user.AssignRole(newRole);

        }

        public void RemoveRole(User user)
        {
            user.RemoveRole(Id);
        }
    }
}
