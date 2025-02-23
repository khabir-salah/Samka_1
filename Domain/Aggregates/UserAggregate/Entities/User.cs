using System.Security.Cryptography;
using Domain.Aggregates.UserAggregate.Enum;
using Domain.Exceptions;
using Domain.Sheared.Entities;

namespace Domain.Aggregates.UserAggregate.Entities
{
    public class User : AuditableEntity<Guid>
    {
        public string Email { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid RoleId { get; private set; }
        public Role Role { get; private set; }
        public bool IsActive { get; private set; } = false;
        public Gender Gender { get; private set; }
        public string? PasswordResetToken { get; private set; }
        public bool IsEmailConfirmed { get; private set; } = false;
        public bool IsPhoneNumberConfirmed { get; private  set; } = false;
        public DateTime? PasswordExpireTime { get; private set; }
        public string RefreshToken { get; private set; }
        public DateTime RefreshTokenExpiration { get; private set; }
        public string ReferralCode { get; private set; }




        #region Constructor
        public User() { }


        public User(string phoneNumber, string email, string passwordHash, string firstName, string lastName, Guid role)
        {

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new BaseDomainException("Email and password are required.");
            }
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new BaseDomainException("First Name and Last Name are required");
            }
            if (role == Guid.Empty)
            {
                throw new BaseDomainException("Role Cannot be Null");
            }

            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            RoleId = role;
            PhoneNumber = phoneNumber;
            ReferralCode = Guid.NewGuid().ToString().Substring(0,5).ToUpper();
        }

        #endregion

    

        public void UpdateProfile(string firstName, string lastName, string phoneNumber, string profilePicture = null)
        {
            FirstName = firstName ?? FirstName;
            LastName = lastName ?? LastName;
            PhoneNumber = phoneNumber ?? PhoneNumber;
        }

        public void ChangePassword(string newPasswordHash, string oldPasswordHash)
        {
            if (PasswordHash != oldPasswordHash)
            {
                throw new BaseDomainException("Old password is incorrect.");
            }

            PasswordHash = newPasswordHash;
        }

        public void ActivateUserEmail()
        {
           IsActive = true;
            IsEmailConfirmed = true;
            PasswordResetToken = null;
            PasswordResetToken = null;
        }

        public void ConformProviderNumber()
        {
            this.IsPhoneNumberConfirmed = true;
        }

        public void AssignRole(Role role)
        {
            if (role == null)
            {
                throw new BaseDomainException("Role Can NOT Be Null");
            }
            Role = role;
        }

        public void RemoveRole(Guid roleId)
        {
            Role = null;
        }

        public string SetRefreshToken()
        {
            RefreshTokenExpiration = DateTime.UtcNow.AddDays(7);
            return RefreshToken = GenerateRefreshToken();
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

    }
}
