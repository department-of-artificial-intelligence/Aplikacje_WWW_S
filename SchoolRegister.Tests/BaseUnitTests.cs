using SchoolRegister.DAL.EF;

namespace SchoolRegister.Tests.UnitTests;

public abstract class BaseUnitTests {
    protected readonly AppDbContext DbContext = null!;
    public BaseUnitTests (AppDbContext dbContext) {
        DbContext = dbContext;
    }
}