using StockService.Application.Locals.Commands;
using StockService.Domain.Locals.Entities;

namespace StockService.Application.Locals.Services.CreateLocalServices;

public interface ICreateLocalService
{
    Guid Execute(CreateLocalCommand command);
}