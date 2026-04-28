using DAL.EF;

namespace Services.Services
{
    public abstract class BaseService
    {
        protected readonly MyDbContext _dbContext;

        public BaseService(MyDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}