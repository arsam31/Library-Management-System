namespace Library.Client.Logger
{
    public interface ILogger
    {
        void LogRequest(object dto, HttpContext httpContext);
        void LogResponse<T>(ResponseResult<T> response);
    }
}
