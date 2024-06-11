using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.ConcreteServices;
using Kolokwium.Services.Interfaces;
using Microsoft.Extensions.Logging;

public class UserService : BaseService, IUserService
{
    public UserService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
    {
    }

    public void AddOrUpdateUser(UserVm userVm)
    {

        var user = Mapper.Map<User>(userVm);

        if (user.Id == 0)
        {
            DbContext.Users.Add(user);
        }
        else
        {
            DbContext.Users.Update(user);
        }

        DbContext.SaveChanges();

    }

    public UserVm GetUser(int id)
    {
        var user = DbContext.Users.Find(id);

        return Mapper.Map<UserVm>(user);
    }

    public IEnumerable<UserVm> GetUsers()
    {
        var users = DbContext.Users.ToList();

        return Mapper.Map<IEnumerable<UserVm>>(users);
    }
}