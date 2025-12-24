using StockService.Application.Locals.Commands;
using StockService.Domain.Locals.Repositories;
using StockService.Domain.Locals.Entities;
using StockService.Domain.Locals.ValueObjects;

namespace StockService.Application.Locals.Services.CreateLocalServices;

public class CreateLocalService : ICreateLocalService
{
    private readonly ILocalRepository _localRepository;

    public CreateLocalService(ILocalRepository localRepository)
    {
        _localRepository = localRepository;
    }

    public Guid Execute(CreateLocalCommand command)
    {
        var localExists = _localRepository.GetByName(command.Name);
        if (localExists != null) 
            throw new ArgumentException("Local already exists with this name");

        var local = new Local(new LocalId(Guid.NewGuid()), command.Name);
        
        _localRepository.Add(local);
        _localRepository.SaveChanges();

        return local.Id.Value;
    }
}