using AvailableLocations.Domain.Interfaces;

namespace AvailableLocations.Services.Interfaces
{
    /// <summary>
    /// This is the Location Service, I used Base because the exercice only require one entity
    /// </summary>
    public interface IBaseService<TEntidad, TEntidadID>
        :IAdd<TEntidad>, IListLocation<TEntidad, TEntidadID>
    {
    }
}
