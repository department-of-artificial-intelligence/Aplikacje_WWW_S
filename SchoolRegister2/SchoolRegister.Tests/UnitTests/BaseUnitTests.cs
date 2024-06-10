using SchoolRegister.DAL.EF;
namespace SchoolRegister.Tests.UnitTests;
public abstract class BaseUnitTests
{
    protected readonly ApplicationDbContext DbContext = null!;
    public BaseUnitTests(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
}
