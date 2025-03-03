using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence.EFCore.UnitOfWork.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _dbContextTransaction;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
             _context = context;
        }

        public void BeginTransaction()
        {
            if (_dbContextTransaction != null)
                throw new InvalidOperationException("Uma transação já está em andamento.");

            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_dbContextTransaction == null)
                throw new InvalidOperationException("Nenhuma transação foi iniciada.");

            try
            {
                _context.SaveChanges();
                _dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                _dbContextTransaction?.Rollback();
                throw;
            }
            finally
            {
                _dbContextTransaction?.Dispose();
                _dbContextTransaction = null;
            }
        }
    }
}