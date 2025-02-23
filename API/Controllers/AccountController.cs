using Application.Services.NotificationProvider;
using Application.Services.TokenGeneration;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.Create.RegisterServiceProvider;
using static Application.Commands.Create.RegisterUser;
using static Application.Services.Authentication.ConfirmEmail;
using static Application.Services.Authentication.LoginUser;

namespace SamkaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMediator mediator, IEmailConfirmationToken emailTOken, IEmailSender emailSender, IBackgroundJobClient _backgroundJobClient, ISMSSender sMSSender) : ControllerBase
    {
        [HttpPost("Sign-Up")]
        public async Task<IActionResult> RegisterAsync(RegisterUserCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Input Invalid");
            }
            var response = await mediator.Send(request);
            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            var token = await emailTOken.GenerateEmailConfirmationToken(response.Data.email);
            var callbackUrl = Url.Action("Confirm_Email", "Account", new { userId = response.Data.userId, token.Token }, protocol: HttpContext.Request.Scheme);
            _backgroundJobClient.Enqueue(() =>  emailSender.SendEmailVerificationMessage(response.Data.email, response.Data.name, callbackUrl));

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Input Invalid");
            }

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("Confirm_Email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand request)
        {
            if (ModelState.IsValid)
            {
                return BadRequest("Invalid Input");
            }

            await mediator.Send(request);
            return Ok();
        }

        [HttpPost("Forgot_Password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var token = await emailTOken.GenerateEmailConfirmationToken(email);
            var callbackUrl = Url.Action("Confirm_Email", "Account", new {token.userId, token.Token }, Request.Scheme);
            _backgroundJobClient.Enqueue(() =>  emailSender.SendPasswordResetMessage(email, token.Name, callbackUrl));

            return Ok();
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            throw new NotImplementedException();
        }

        [HttpPost("VerificationCode")]
        public async Task<IActionResult> PhoneNumberVerification(string PhoneNumber)
        {
            var response = await sMSSender.SendVerificationCode(PhoneNumber);
            return Ok(response);
        }

        [HttpPost("ProviderSignUp")]
        public async Task<IActionResult> ProviderSignUp(RegisterProviderCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Input Invalid");
            }
            var response = await mediator.Send(request);
            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            var token = await emailTOken.GenerateEmailConfirmationToken(response.Data.email);
            var callbackUrl = Url.Action("Confirm_Email", "Account", new { userId = response.Data.userId, token.Token }, protocol: HttpContext.Request.Scheme);
            _backgroundJobClient.Enqueue(() => emailSender.ProviderWelcomeMessage(response.Data.email, response.Data.name, callbackUrl));

            return Ok();
        }
    }
}
