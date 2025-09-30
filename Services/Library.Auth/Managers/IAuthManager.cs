using Library.Auth.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace Library.Auth.Managers
{
    public interface IAuthManager
    {
        Task<ResponseResult<LoginResponse>> LoginAsync(Library.Auth.Models.LoginRequest login);
        Task<ResponseResult<SignUpResponse>> SignUpAsync(SignUpRequest user);
    }
}
