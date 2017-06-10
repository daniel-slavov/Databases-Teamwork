using System;
using System.Data.Entity;
using MoviesDatabase.Data.Contracts;

namespace MoviesDatabase.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext cannot be null.");
            }

            this.dbContext = dbContext;
        }

        public void Dispose()
        {
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
