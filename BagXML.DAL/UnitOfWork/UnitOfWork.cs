using System.Data;

namespace BagXML.DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;
        public IDbConnection DBConnection { get; }

        public UnitOfWork(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public TRepository GetRepository<TRepository>(TRepository repository = default!) where TRepository : class
            => repository ?? throw new ArgumentNullException();

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DBConnection.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
