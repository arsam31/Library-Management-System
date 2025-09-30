using Library.Auth.Models;

namespace Library.Auth.Repositories
{
    public interface IAuthRepository
    {
        Task<UserVerificationResult> IsLoginExistsAsync(string email);
        Task<ResponseResult<SignUpResponse>> SignUpAsync(SignUpRequest user);
    }
}
