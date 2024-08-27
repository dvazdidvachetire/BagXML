using System.Data;

namespace BagXML.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>Создает запись в базе данных</summary>
        /// <param name="entity">передаваемая сущность</param>
        /// <param name="dbTransaction">транзакция</param>
        /// <returns>возвращает id сохраненной сущности</returns>
        int Create(T entity, IDbTransaction? dbTransaction = null);
    }
}
