namespace Store.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
