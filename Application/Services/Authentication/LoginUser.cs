using Application.DTOs;
using Application.Exceptions;
using Domain.Aggregates.UserAggregate.Constants;
using Domain.Repositories;
using Infrastructure.JWT;
using MediatR;

namespace Application.Services.Authentication;

public class LoginUser
{
    public record LoginRequestModel(string email, string password) : IRequest<LoginResponseModel>;

    public record LoginResponseModel(string accessToken, string RefreshToken);

    public class Handler(IUserRepository userRepository, IJwtBearerConfig jwtBearer, IUnitOfWork unitOfWork) : IRequestHandler<LoginRequestModel, LoginResponseModel>
    {
        public async Task<LoginResponseModel> Handle(LoginRequestModel request, CancellationToken cancellationToken)
        {
            var getUser = await userRepository.GetUserAsync(u => u.Email == request.email) ?? throw new NullReferenceException($" Email {request.email} Can NOT Be Found");

            if (getUser.Role.Name == RoleConst.Provider)
            {
                getUser.ConformProviderNumber();
            }

            if (!getUser.IsPhoneNumberConfirmed || getUser.IsEmailConfirmed || getUser.IsActive == false)
            {
                throw new CredentialNotConfirmed("Your Email Or Phone Number Is Not Confirmed");
            }

            var hashPassword = BCrypt.Net.BCrypt.Verify(request.password, getUser.PasswordHash);

            if(hashPassword)
            {
                var refreshToken = getUser.SetRefreshToken();
                await unitOfWork.Save();

                var token = await jwtBearer.GenerateJwtAsync(getUser);

                return new LoginResponseModel(token, refreshToken);
            }

            throw new InValidCredential("Credential Not Valid");
        }
    }
}