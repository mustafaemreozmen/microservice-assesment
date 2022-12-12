using System.Linq.Expressions;
using Directory.Data.Entities;
using Directory.Data.Repositories.Interfaces;

namespace Directory.Data.Repositories;

public class InformationRepository : BaseRepository<Information>, IInformationRepository
{
    public InformationRepository(DirectoryContext directoryContext) : base(directoryContext)
    {
    }
}