namespace AvailableLocations.Domain.Interfaces.Repositories
{
    /// <summary>
    /// This is the Location Repository, I used Base because the exercice only require one entity
    /// </summary>
    public interface IBaseRepository<IEntity, TEntityID>
        : IAdd<IEntity>, IListLocation<IEntity, TEntityID>, ITransaction
    {
    }
}

