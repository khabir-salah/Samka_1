

using Application.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Authentication
{
    public class ConfirmEmail
    {
        public record ConfirmEmailCommand(Guid userId, string token) : IRequest;

        public class Handler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<ConfirmEmailCommand>
        {
            public async Task Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
            {
                var getUser = await userRepository.GetUserAsync(u => u.Id == request.userId && u.PasswordResetToken == request.token) ?? throw new NullReferenceException("User Not Valid");

                if (getUser.PasswordExpireTime < DateTime.UtcNow)
                {
                    getUser.ActivateUserEmail();
                    await unitOfWork.Save();
                }
                throw new TimeOutException("Password Expire Time TimeOut");
            }
        }
    }
}
