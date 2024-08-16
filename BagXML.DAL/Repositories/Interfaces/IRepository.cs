namespace BagXML.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        int Create(T entity);
    }
}
