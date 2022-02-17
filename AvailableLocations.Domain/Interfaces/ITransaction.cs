namespace AvailableLocations.Domain.Interfaces
{
    //Public Interface that apply the changes to the ORM.
    public interface ITransaction
    {
        //This is the Method to Save al changes over the entity
        void SaveAllChanges();
    }
}
