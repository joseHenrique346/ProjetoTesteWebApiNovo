namespace Infrastructure.Persistence.EFCore.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
