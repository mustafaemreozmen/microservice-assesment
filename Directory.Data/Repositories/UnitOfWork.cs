using System.Linq.Expressions;
using Directory.Data.Entities;
using Directory.Data.Repositories.Interfaces;

namespace Directory.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private DirectoryContext _directoryContext;
    private IInformationRepository _informationRepository;
    private IPersonRepository _personRepository;

    public UnitOfWork(DirectoryContext directoryContext)
    {
        _directoryContext ??= directoryContext;
    }
    public IInformationRepository InformationRepository => _informationRepository ?? new InformationRepository(_directoryContext);
    public IPersonRepository PersonRepository => _personRepository ?? new PersonRepository(_directoryContext);

    public void Commit()
    {
        _directoryContext.SaveChanges();
    }
}