namespace Directory.Data.Repositories.Interfaces;

public interface IUnitOfWork
{
    IInformationRepository InformationRepository { get; }
    IPersonRepository PersonRepository { get; }

    void Commit();
}