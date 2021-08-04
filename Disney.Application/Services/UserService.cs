using AutoMapper;
using Disney.Application.Auth;
using Disney.Application.Commands;
using Disney.Application.Helpers;
using Disney.Application.Interfaces;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Services
{
    public class UserService : IUserService
    {
        #region Obj and Constructor
        private readonly UserManager<User> userManager;
        private readonly JwtSettings jwtSettings;
        private readonly IConfiguration Iconfiguration;        
        private readonly IUserStore<User> IuserStore;
        private readonly IMapper mapper;
        private readonly IUserRepository IuserRepository;
        public UserService(UserManager<User> userManager,
                           JwtSettings jwtSettings,
                           IConfiguration Iconfiguration,
                           IUserStore<User> IuserStore, 
                           IMapper mapper, 
                           IUserRepository IuserRepository)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.Iconfiguration = Iconfiguration;
            this.IuserStore = IuserStore;
            this.IuserRepository = IuserRepository;
            this.mapper = mapper;
        }
        #endregion

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var result = await IuserRepository.GetAllUsers();
            var response = mapper.Map<IEnumerable<UserDTO>>(result);

            return response;
        }

        public async Task<AuthenticationResult> LoginUser(LoginUser request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return ValidateUserException(AuthValidationErrorResponses.UserDoesNotExist);

            var userHasValidPassword = await userManager.CheckPasswordAsync(user, request.Password);
            if (!userHasValidPassword)
                return ValidateUserException(AuthValidationErrorResponses.UserOrPasswordAreIncorrect);

            return GenerateAuthResult(user);
        }

        public async Task<AuthenticationResult> RegisterUser(RegisterUser request)
        {
            var existingUser = await userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
                return ValidateUserException(AuthValidationErrorResponses.UserAlreadyExist);

            var newUser = mapper.Map<User>(request);

            var createdUser = await userManager.CreateAsync(newUser, request.Password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    ErrorMessages = createdUser.Errors.Select(x => x.Description)
                };
            }

            return GenerateAuthResult(newUser);
        }

        public async Task<Result> DeleteUser(DeleteUser request)
        {
            var requester = await IuserStore.FindByIdAsync(request.GetUser(), new CancellationToken());
            if (requester == null)
                return new Result().NotFound();

            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return ValidateUserException(AuthValidationErrorResponses.UserDoesNotExist);

            var entity = mapper.Map<User>(user);

            await IuserRepository.UpdateUser(entity);
            return new Result().Success($"Se eliminó el User {entity.UserName}");
        }

        private AuthenticationResult GenerateAuthResult(IdentityUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString("d")),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id),
                    new Claim("createdAt", DateTimeHelper.GetSystemDate().ToString()),
                }),
                Expires = DateTimeHelper.GetSystemDate().AddHours(Convert.ToInt32(Iconfiguration.GetSection("JwtSettings:ValidHours").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                HasErrors = false,
                Token = tokenHandler.WriteToken(token)
            };
        }
        private AuthenticationResult ValidateUserException(string validationMessage)
        {
            return new AuthenticationResult
            {
                ErrorMessages = new[] { validationMessage }
            };
        }
    }
}
