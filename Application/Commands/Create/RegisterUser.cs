using Application.DTOs;
using Application.Services.TokenGeneration;
using Domain.Aggregates.UserAggregate.Constants;
using Domain.Aggregates.UserAggregate.Entities;
using Domain.Repositories;
using MediatR;


namespace Application.Commands.Create
{
    public class RegisterUser
    {
        public record RegisterUserCommand : IRequest<BaseResponse<RegisterResponseModel>>
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
            public required string PhoneNumber { get; set; }
            public required string Gender { get; set; }
        }

        public record RegisterResponseModel(Guid userId, string email, string name);

        public class Handler(IUserRepository userRepository, IEmailConfirmationToken emailToken, IUnitOfWork unitOfWork) : IRequestHandler<RegisterUserCommand, BaseResponse<RegisterResponseModel>>
        {
            public async Task<BaseResponse<RegisterResponseModel>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var getUser = await userRepository.IsExisAsync(u => u.Email == request.Email);
                if (!getUser)
                {
                    return new BaseResponse<RegisterResponseModel>
                    {
                        Message = $"Email {request.Email} already exist",
                        IsSuccess = false
                    };
                }
                
                var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);

                var newUser = new User(request.PhoneNumber, request.Email, hashPassword, request.FirstName, request.LastName, getRole.Id);
                newUser.Role.AssignRole(RoleConst.Client, newUser);

                await userRepository.RegisterUserAsync(newUser);
                await unitOfWork.Save();

                return new BaseResponse<RegisterResponseModel>
                {
                    IsSuccess = true,
                    Data = new RegisterResponseModel(newUser.Id, newUser.Email, newUser.FirstName)
                };
            }
        }
    }
}
