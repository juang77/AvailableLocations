namespace AvailableLocations.Domain.Interfaces
{
    /// <summary>
    /// This is the Public interface for the Create part of CRUD for Locations.
    /// </summary>
    public interface IAdd<IEntity>
    {
        //This is the Method for Add new items from Location Entity
        IEntity Add(IEntity entity);
    }
}
