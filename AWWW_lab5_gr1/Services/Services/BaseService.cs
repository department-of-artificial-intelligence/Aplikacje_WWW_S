using DAL;

namespace Services.Services
{
    public abstract class BaseService
    {
        protected readonly AppDbContext _dbContext;

        public BaseService(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}