using System.ComponentModel.DataAnnotations;
using StockService.Application.Common.Result.Types;

namespace StockService.Application.Common.Result;

public class ResultService : IResultService
{
    private readonly List<ResultError> _errors = new();

    public void AddMessage(string message)
    {
        _errors.Add(new ResultError(message));
    }
    
    public void Clear()
    {
        _errors.Clear();
    }

    public bool HasErrors()
    {
        return _errors.Count != 0;
    }

    public object GetErrors()
    {
        return new { Errors = _errors};
}

    
}