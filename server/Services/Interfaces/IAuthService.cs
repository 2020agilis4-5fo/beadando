using Services.Implementations;
using System;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult<int>> AttemptRegisterAsync(LoginDto login);

        Task<AuthResult<int>> AttemptLoginAsync(LoginDto login);

        Task<AuthResult<int>> AttemptLogoutAsync();
    }
}
