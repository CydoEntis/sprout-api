//
// using AutoMapper;
// using Microsoft.AspNetCore.Identity;
// using TaskGarden.Api.Constants;
// using TaskGarden.Api.Dtos.Auth;
// using TaskGarden.Api.Errors;
// using TaskGarden.Application.Exceptions;
// using TaskGarden.Application.Services.Contracts;
// using TaskGarden.Infrastructure.Entities;
//
// namespace TaskGarden.Application.Services;
//
// public class AuthManager : IAuthManager
// {
//     private readonly UserManager<AppUser> _userManager;
//     private readonly ICookieService _cookieService;
//     private readonly ISessionService _sessionService;
//     private readonly IEmailTemplateService _emailTemplateService;
//     private readonly IEmailService _emailService;
//     private readonly ITokenService _tokenService;
//     private readonly IMapper _mapper;
//
//     private AppUser? _user;
//
//     public AuthManager(UserManager<AppUser> userManager,
//         IMapper mapper, ITokenService tokenService, ICookieService cookieService, ISessionService sessionService,
//         IEmailTemplateService emailTemplateService, IEmailService emailService)
//     {
//         _userManager = userManager;
//         _mapper = mapper;
//         _tokenService = tokenService;
//         _cookieService = cookieService;
//         _sessionService = sessionService;
//         _emailTemplateService = emailTemplateService;
//         _emailService = emailService;
//     }
//
//     public async Task<AuthenticatedResponseDto> Login(LoginRequestDto loginDto)
//     {
//         _user = await _userManager.FindByEmailAsync(loginDto.Email);
//         if (_user == null)
//             throw new ValidationException("email", ExceptionMessages.InvalidCredentials);
//
//         if (!await _userManager.CheckPasswordAsync(_user, loginDto.Password))
//             throw new ValidationException("email", ExceptionMessages.InvalidCredentials);
//
//         var accessToken = _tokenService.GenerateAccessToken(_user);
//         var refreshToken = _tokenService.GenerateRefreshToken();
//         await _sessionService.CreateSessionAsync(_user.Id, refreshToken);
//         _cookieService.Append(CookieConsts.RefreshToken, refreshToken.Token, true, refreshToken.ExpiryDate);
//
//         return new AuthenticatedResponseDto() { Message = "Logged in successfully.", AccessToken = accessToken };
//     }
//
//     public async Task<AuthenticatedResponseDto> Register(RegisterRequestDto registerDto)
//     {
//         var existingEmail = await _userManager.FindByEmailAsync(registerDto.Email);
//         if (existingEmail is not null)
//             throw new ValidationException("email", ExceptionMessages.EmailInUse);
//
//         var _user = _mapper.Map<AppUser>(registerDto);
//         var result = await _userManager.CreateAsync(_user, registerDto.Password);
//
//         if (!result.Succeeded)
//             throw new ResourceCreationException(ExceptionMessages.RegistrationFailed);
//
//         return await Login(new LoginRequestDto { Email = registerDto.Email, Password = registerDto.Password });
//     }
//
//     public async Task<RefreshTokensResponseDto> RefreshTokens()
//     {
//         var refreshToken = _cookieService.Get(CookieConsts.RefreshToken);
//         if (string.IsNullOrEmpty(refreshToken))
//             throw new NotFoundException(ExceptionMessages.TokenNotFound);
//
//         var session = await _sessionService.GetSessionAsync(refreshToken);
//         if (session is null)
//             throw new NotFoundException(ExceptionMessages.SessionNotFound);
//
//         var _user = await _userManager.FindByIdAsync(session.UserId);
//         if (_user is null)
//             throw new NotFoundException(ExceptionMessages.UserNotFound);
//
//         var newAccessToken = _tokenService.GenerateAccessToken(_user);
//         var newRefreshToken = _tokenService.GenerateRefreshToken();
//
//         await _sessionService.InvalidateSessionAsync(session);
//         await _sessionService.CreateSessionAsync(_user.Id, newRefreshToken);
//
//         _cookieService.Append(CookieConsts.RefreshToken, newRefreshToken.Token, true, newRefreshToken.ExpiryDate);
//
//         return new RefreshTokensResponseDto()
//             { Message = "Tokens refreshed successfully.", AccessToken = newAccessToken };
//     }
//
//     public async Task<LogoutResponseDto> Logout()
//     {
//         var refreshToken = _cookieService.Get(CookieConsts.RefreshToken);
//         if (string.IsNullOrEmpty(refreshToken))
//             throw new NotFoundException(ExceptionMessages.TokenNotFound);
//
//         var session = await _sessionService.GetSessionAsync(refreshToken);
//         if (session is null)
//             throw new NotFoundException(ExceptionMessages.SessionNotFound);
//
//         await _sessionService.InvalidateSessionAsync(session);
//         _cookieService.Delete(CookieConsts.RefreshToken);
//         return new LogoutResponseDto() { Message = "Logged out successfully." };
//     }
//
//     public async Task<ForgotPasswordResponseDto> ForgotPasswordAsync(ForgotPasswordRequestDto forgotPasswordRequestDto)
//     {
//         _user = await _userManager.FindByEmailAsync(forgotPasswordRequestDto.Email);
//         if (_user is null)
//             throw new NotFoundException(ExceptionMessages.UserNotFound);
//         var resetToken = await _userManager.GeneratePasswordResetTokenAsync(_user);
//         var encodedToken = Uri.EscapeDataString(resetToken);
//         var resetUrl = $"{ProjectConsts.DevUrl}/reset-password?token={encodedToken}";
//         var placeholders = new Dictionary<string, string>
//         {
//             { "Recipient's Email", forgotPasswordRequestDto.Email },
//             { "Reset Link", resetUrl }
//         };
//
//         var emailBody = _emailTemplateService.GetEmailTemplate("ForgotPasswordTemplate", placeholders);
//         await _emailService.SendEmailAsync("TaskGarden", forgotPasswordRequestDto.Email, "Forgot Password Request",
//             emailBody);
//
//         return new ForgotPasswordResponseDto()
//             { Message = "If an account with that email exists, a password reset link will be sent." };
//     }
//
//     public async Task<ResetPasswordResponseDto> ResetPasswordAsync(ResetPasswordRequestDto requestDto)
//     {
//         _user = await _userManager.FindByEmailAsync(requestDto.Email);
//         if (_user is null)
//             throw new NotFoundException(ExceptionMessages.UserNotFound);
//
//         var decodedToken = Uri.UnescapeDataString(requestDto.Token);
//
//         var tokenIsValid = await _userManager.VerifyUserTokenAsync(
//             _user,
//             _userManager.Options.Tokens.PasswordResetTokenProvider,
//             "ResetPassword",
//             decodedToken
//         );
//
//         if (!tokenIsValid)
//             throw new InvalidTokenException(ExceptionMessages.TokenInvalid);
//
//         var currentPasswordHash = _user.PasswordHash;
//         var passwordHasher = new PasswordHasher<AppUser>();
//         var passwordVerificationResult =
//             passwordHasher.VerifyHashedPassword(_user, currentPasswordHash, requestDto.NewPassword);
//
//         if (passwordVerificationResult == PasswordVerificationResult.Success)
//             throw new AlreadyExistsException("new-password", ExceptionMessages.OldPassword);
//
//         var resetPasswordResult = await _userManager.ResetPasswordAsync(_user, decodedToken, requestDto.NewPassword);
//         if (!resetPasswordResult.Succeeded)
//             throw new OperationException(ExceptionTitles.PasswordResetException,
//                 ExceptionMessages.PasswordResetFailed);
//
//         return new ResetPasswordResponseDto() { Message = "Password has been reset." };
//     }
//
//     public async Task<ChangePasswordResponseDto> ChangePasswordAsync(string userId, ChangePasswordRequestDto requestDto)
//     {
//         _user = await _userManager.FindByIdAsync(userId);
//         if (_user is null)
//             throw new NotFoundException(ExceptionMessages.UserNotFound);
//
//         var isCurrentPasswordValid = await _userManager.CheckPasswordAsync(_user, requestDto.CurrentPassword);
//         if (!isCurrentPasswordValid)
//             throw new ValidationException("current-password", ExceptionMessages.CurrentPasswordMismatch);
//
//         var updateResult =
//             await _userManager.ChangePasswordAsync(_user, requestDto.CurrentPassword, requestDto.NewPassword);
//         if (!updateResult.Succeeded)
//             throw new ResourceModificationException(ExceptionMessages.ChangePasswordFailed);
//
//         return new ChangePasswordResponseDto() { Message = "Password has been changed." };
//     }
// }