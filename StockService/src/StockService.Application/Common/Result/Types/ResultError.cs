namespace StockService.Application.Common.Result.Types;

public class ResultError
{
    public string Message { get; private set; }

    public ResultError(string message)
    {
        Message = message;
    }
}