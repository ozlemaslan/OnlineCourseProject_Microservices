using FreeCourse.Shared.Dtos;
using FreeCourse.Web.Models;
using IdentityModel.Client;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<ResponseDto<bool>> SignIn(SigninInput signinInput);

        Task<TokenResponse> GetAccessByRefreshToken();
        Task RevokeRefreshToken();

    }
}
