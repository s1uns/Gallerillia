using Microsoft.AspNetCore.Identity;


namespace BLL.IdentityManagement.Interfaces
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateAsync(IdentityUser user);
    }
}
