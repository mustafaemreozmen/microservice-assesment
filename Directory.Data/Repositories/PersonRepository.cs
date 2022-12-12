using System.Linq.Expressions;
using Directory.Data.Entities;
using Directory.Data.Repositories.Interfaces;

namespace Directory.Data.Repositories;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(DirectoryContext directoryContext) : base(directoryContext)
    {
    }
}