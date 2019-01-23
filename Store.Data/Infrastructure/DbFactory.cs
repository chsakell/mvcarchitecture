namespace Store.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private StoreEntities _dbContext;

        public StoreEntities Init()
        {
            return _dbContext ?? (_dbContext = new StoreEntities());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
