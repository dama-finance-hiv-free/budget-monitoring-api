namespace Dama.Core.Common.Core;

public class BaseResponse
{
    public BaseResponse()
    {
        Success = true;
        Message = string.Empty;
    }

    public BaseResponse(string message = null)
    {
        Success = true;
        Message = message;
    }

    public BaseResponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
}