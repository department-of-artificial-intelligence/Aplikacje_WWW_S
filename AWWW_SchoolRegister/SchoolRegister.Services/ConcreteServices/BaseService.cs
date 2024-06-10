using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.Services.ConcreteServices
{
  public abstract class BaseService
  {
    protected readonly ApplicationDbContext DbContext = null!;
    protected readonly ILogger Logger = null!;
    protected readonly IMapper Mapper = null!;

    protected readonly UserManager<User> UserManager = null!;
    public BaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> manager)
    {
      DbContext = dbContext;
      Logger = logger;
      Mapper = mapper;
      UserManager = manager;
    }
  }
}