using Domain.Sheared.Entities;

namespace Domain.Sheared.ValueObjects
{
    public class BankDetails : AuditableEntity<Guid>
    {
        public string BankName { get; private set; } = default!;
        public string AccountNumber { get; private set; } = default!;
        public string BranchName { get; private set; } = default!;

        #region Constructor
        public BankDetails(string bankName, string accountNumber, string branchName)
        {
            if (string.IsNullOrWhiteSpace(bankName))
                throw new ArgumentException("Bank name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(branchName))
                throw new ArgumentException("Branch name cannot be null or empty.");

            BankName = bankName;
            AccountNumber = accountNumber;
            BranchName = branchName;
        }
        #endregion

        public void UpdateBankDetails(string bankName, string accountNumber, string branchName)
        {
            if (string.IsNullOrWhiteSpace(bankName))
            {
                throw new ArgumentNullException(nameof(bankName), "Bank name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentNullException(nameof(accountNumber), "Account number cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(branchName))
            {
                throw new ArgumentNullException(nameof(branchName), "Branch cannot be null or empty.");
            }
            BankName = bankName;
            AccountNumber = accountNumber;
            BranchName = branchName;
        }
    }
}
