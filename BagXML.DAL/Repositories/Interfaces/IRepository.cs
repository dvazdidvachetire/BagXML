namespace BagXML.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
    }
}
