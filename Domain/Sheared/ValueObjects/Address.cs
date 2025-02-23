

using Domain.Sheared.Enum;

namespace Domain.Sheared.ValueObjects
{
    public class Address
    {
        public string StreetName { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string State { get; private set; } = default!;
        public string LocalGovernment { get; private set; } = default!;

        #region Constructor
        private Address() { }
        internal Address(string streetName, string city, State state, string localGovernment)
        {
            StreetName = streetName;
            City = city;
            State = state;
            LocalGovernment = localGovernment;
        }
        #endregion

        #region Behaviour
        public static Address CreateAddress(string streetName, string city, State state, string localGovernment)
            => new Address(streetName, city, state, localGovernment);
        public void UpdateLocalGovernment(string localGovernment) => LocalGovernment = localGovernment;
        public void UpdateStreetName(string streetName) => StreetName = streetName;
        public void UpdateCity(string city) => City = city;
        public void UpdateState(State state) => State = state;
        //public override int GetHashCode() => HashCode.Combine( StreetName, City, State, LocalGovernment);
        public override bool Equals(object obj)
        {
            if (obj is not Address other) return false;
            return
                StreetName == other.StreetName &&
                City == other.City &&
                State == other.State &&
                LocalGovernment == other.LocalGovernment;
        }
        #endregion
    }
}
