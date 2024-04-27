using BLL.IdentityManagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BLL.IdentityManagement
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _config;
        private readonly UserManager<IdentityUser> _userManager;

        public JwtTokenGenerator(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _config = configuration;
            _userManager = userManager;
        }
        public async Task<string> GenerateAsync(IdentityUser user)
        {
            var claims = GetUserClaims(user);
            var roleNames = await _userManager.GetRolesAsync(user);
            AddRoleClaims(claims, roleNames);

            var key = _config.GetRequiredSection("JWT")["Secret"];


            var header = new JwtHeader(
                            new SigningCredentials(
                                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), 
                                SecurityAlgorithms.HmacSha256));

            var token = new JwtSecurityToken(header, new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static List<Claim> GetUserClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(30)).ToUnixTimeSeconds().ToString())
            };

            return claims;
        }

        private static void AddRoleClaims(IList<Claim> claims, IList<string> roleNames)
        {
            foreach (var roleName in roleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));
                claims.Add(new Claim("role", roleName));

            }
        }
    }
}