using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;


namespace SchoolRegister.Services.ConcreteServices
{
public abstract class BaseService {
protected readonly ApplicationDbContext DbContext = null!;
protected readonly ILogger Logger = null!;
protected readonly IMapper Mapper = null!;
public BaseService (ApplicationDbContext dbContext, IMapper mapper, ILogger logger) {
    DbContext = dbContext;
    Logger = logger;
    Mapper = mapper;
}
}
}