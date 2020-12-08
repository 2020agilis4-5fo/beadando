using Common.Dto;
using Data.Models;
using Services.Implementations;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult<int>> AttemptRegisterAsync(LoginDto login);

        Task<AuthResult<int>> AttemptLoginAsync(LoginDto login);

        Task<AuthResult<int>> AttemptLoginWithFacebookAsync(FacebookLoginDto dto);

        bool ValidateFbData(FBData dto, FacebookLoginDto claims);

        Task<AuthResult<int>> AttemptLogoutAsync();

        IQueryable<ImageHubUser> GetAllUsers();

        IQueryable<ImageHubUser> GetAllFriendableUsers();

        bool CheckIfUserExists(int userId);

        int GetLoggedinUserId();

        bool CheckIfUserIsAuthorized(int idClaim);
    }
}
