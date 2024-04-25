using BLL.IdentityManagement.Interfaces;
using Infrustructure.Dto.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gallerillia.Server.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;

        }

        /// <summary>
        /// Creates a new user account.
        /// </summary>
        /// <param name="request">The request to create a user account.</param>
        /// <remarks>
        /// If the operation is successful, it will return a SignUpResultDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUpUser([FromBody] CredentialsDto request)
        {
            var result = await _accountService.CreateUserAsync(request);
            return this.CreateResponse(result);
        }

        /// <summary>
        /// Performs user login.
        /// </summary>
        /// <param name="request">The request to perform user login</param>    
        /// <remarks>
        /// If the operation is successful, it will return a SignInResultDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] CredentialsDto request)
        {
            var result = await _accountService.SignInAsync(request);
            return this.CreateResponse(result);
        }
    }
}
