using StockService.Domain.Locals.Entities;
using StockService.Domain.Locals.Repositories;
using StockService.Domain.Locals.ValueObjects;

namespace StockService.Application.Locals.Services.GetLocalService;

public class GetLocalService : IGetLocalService
{
    private readonly ILocalRepository _localRepository;

    public GetLocalService(ILocalRepository localRepository)
    {
        _localRepository = localRepository;
    }

    public Local Execute(Guid id)
    {
        var localId = new LocalId(id);
        
        return _localRepository.Get(localId);
    }
}