using System.Collections.Generic;

namespace AvailableLocations.Domain.Interfaces
{
    //Public interface for the Read part of CRUD for Locations.
    public interface IListLocation<IEntity, TEntityID>
    {
        //This is the Method for Get a Full List
        List<IEntity> List();

        //This is the Method for Get one Location by Id
        IEntity SelectById(TEntityID entityId);

        //This is the Method for Get a Locations List in the range of start and end time.
        List<IEntity> SeleccionarByTimeRange(IEntity entity);
    }
}
