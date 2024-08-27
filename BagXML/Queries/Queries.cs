using System.Data;

namespace BagXML.Queries
{
    /// <summary>представляет абстрактный класс для запросов</summary>
    public abstract class Queries<T>
    {
        public abstract int Create(T model, IDbTransaction? dbTransaction = null);
    }
}