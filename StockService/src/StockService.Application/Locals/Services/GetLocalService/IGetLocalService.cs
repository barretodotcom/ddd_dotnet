using StockService.Domain.Locals.Entities;

namespace StockService.Application.Locals.Services.GetLocalService;

public interface IGetLocalService
{
    Local Execute(Guid id);
}