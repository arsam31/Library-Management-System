using Library.Auth.Models;

namespace Library.Auth.AuthLogger
{
    public interface IAuthLogger
    {
        void LogRequest(object dto, HttpContext httpContext);
        void LogResponse<T>(ResponseResult<T> response);
    }
}
