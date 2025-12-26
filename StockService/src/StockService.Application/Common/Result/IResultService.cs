using StockService.Application.Common.Result.Types;

namespace StockService.Application.Common.Result;

public interface IResultService
{
    void AddMessage(string message);
    void Clear();
    object GetErrors();
    bool HasErrors();
}