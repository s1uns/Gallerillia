using BLL.IdentityManagement.Interfaces;
using Core;
using Infrustructure.Dto.Account;
using Infrustructure.ErrorHandling.Errors.Base;
using Microsoft.AspNetCore.Identity;
using Infrustructure.ErrorHandling.Errors.ServiceErrors;
using Microsoft.Extensions.Logging;
using Core.Models;
using Infrustructure.ErrorHandling.Exceptions.Services.Account;
using Microsoft.AspNetCore.Http;
using Infrustructure.Extensions;
using DAL;

namespace BLL.IdentityManagement
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountService> _logger;
        private readonly IHttpContextAccessor _contextAccessor;


        public AccountService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ITokenGenerator tokenGenerator, ApplicationDbContext context, ILogger<AccountService> logger, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenGenerator = tokenGenerator;
            _context = context;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public async Task<Result<SignInResultDto, Error>> CreateUserAsync(CredentialsDto credentials)
        {
            try
            {
                var identityUser = new IdentityUser
                {
                    Email = credentials.Email,
                    UserName = credentials.Email
                };

                var createIdentity = await _userManager.CreateAsync(identityUser, credentials.Password);

                if (createIdentity.Succeeded is false)
                {
                    return IdentityServiceErrors.CreateAccountError(createIdentity.Errors.Select(e => e.Description).FirstOrDefault());
                }

                await AssureRoleCreatedAsync(Roles.User.ToString());
                await _userManager.AddToRoleAsync(identityUser, Roles.User.ToString());
                
                var user = new User
                {

                    Id = Guid.Parse(identityUser.Id),
                    Email = credentials.Email,

                };

                await _context.OrdinaryUsers.AddAsync(user);
                await _context.SaveChangesAsync();

                var token = await _tokenGenerator.GenerateAsync(identityUser);

                return new SignInResultDto
                {
                    UserId = user.Id,
                    Bearer = token
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.CreateUserAsync ERROR: {ex.Message}");

                return IdentityServiceErrors.CreateAccountError("something went wrong.");
            }

        }

        public async Task<Result<SignInResultDto, Error>> SignInAsync(CredentialsDto credentials)
        {
            try
            {
                var identityUser = await _userManager.FindByEmailAsync(credentials.Email);

                if (identityUser is null)
                {
                    throw new SignInExceiption("Wrong email");
                }

                var isCredentialsValid = await _userManager.CheckPasswordAsync(identityUser, credentials.Password);

                if (!isCredentialsValid)
                {
                    throw new SignInExceiption("Wrong password");
                }

                var token = await _tokenGenerator.GenerateAsync(identityUser);
                var result = new SignInResultDto()
                {
                    UserId = Guid.Parse(identityUser.Id),
                    Bearer = token,
                };
                return result;
            }
            catch (SignInExceiption ex)
            {
                _logger.LogError($"BLL.SignInAsync ERROR: {ex.Message}");

                return IdentityServiceErrors.SignInError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.SignInAsync ERROR: {ex.Message}");

                return IdentityServiceErrors.SignInError("something went wrong.");
            }
        }

        private async Task AssureRoleCreatedAsync(string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                return;
            }

            await _roleManager.CreateAsync(new IdentityRole(role));
        }


    }
}