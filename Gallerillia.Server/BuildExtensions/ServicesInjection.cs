




using BLL.AlbumsManagement;
using BLL.IdentityManagement;
using BLL.IdentityManagement.Interfaces;
using BLL.PictureManagement;

namespace Gallerillia.Server.BuildExtensions
{
    internal static class ServicesInjection
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IPictureService, PictureService>();
        }
    }
}
