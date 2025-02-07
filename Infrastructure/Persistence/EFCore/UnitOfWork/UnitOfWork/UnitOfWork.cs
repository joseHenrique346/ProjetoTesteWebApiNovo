using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence.EFCore.UnitOfWork.UnitOfWork
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private IDbContextTransaction dbContextTransaction;
        private readonly AppDbContext _context;

        public void BeginTransaction()
        {
            if (dbContextTransaction != null)
                throw new InvalidOperationException("Uma transação já está em andamento.");

            dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (dbContextTransaction == null)
                throw new InvalidOperationException("Nenhuma transação foi iniciada.");

            try
            {
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbContextTransaction?.Rollback();
                throw; 
            }
            finally
            {
                dbContextTransaction?.Dispose();
                dbContextTransaction = null;
            }
        }
    }
}