
using Domain.Aggregates.ServiceAggregate.Enum;

namespace Domain.Sheared.ValueObjects
{
    public class ServiceProviderProfile
    {
        public Guid ServiceProviderId { get; private set; }
        public string Bio { get; private set; } = default!;
        public ExperieceLevel ExperieceLevel { get; private set; }
        public string YrsOfExp { get; private set; } = default!;
        public double Rating { get; private set; } = default!;
        public bool CanWorkWithCat { get; private set; }
        public bool CanWorkWithDog { get; private set; }
        public string ProfilePicture { get; private set; } = default!;
        public int NumberOfHoursWork { get; private set; }

        public VerificationStatus VerificationStatus { get; private set; }



        public ServiceProviderProfile() { }

        public ServiceProviderProfile(Guid serviceProviderId, Address address, string bio, ExperieceLevel experieceLevel, string yrsOfExp, double rating, string profilePicture)
        {
            ServiceProviderId = serviceProviderId;
            Bio = bio;
            ExperieceLevel = experieceLevel;
            YrsOfExp = yrsOfExp;
            Rating = rating;
            ProfilePicture = profilePicture;
        }

        public void UpdateProviderProfil(Address address, string bio, ExperieceLevel experieceLevel, string yrsOfExp, string profilePicture)
        {
            Bio = bio ?? Bio;
            ExperieceLevel = experieceLevel;
            YrsOfExp = yrsOfExp ?? YrsOfExp;
            ProfilePicture = profilePicture ?? ProfilePicture;

        }

        public void SetAvailability()
        {

        }
    }
}
