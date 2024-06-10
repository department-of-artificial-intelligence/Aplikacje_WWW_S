using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.Services.Configuration.AutoMapperProfiles;
using SchoolRegister.Services.Interfaces;
namespace SchoolRegister.Tests;
public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddAutoMapper(typeof(MainProfile));
    services.AddEntityFrameworkInMemoryDatabase()
    .AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb")
    );
    services.AddIdentity<User, Role>(options =>
    {
      options.SignIn.RequireConfirmedAccount = false;
      options.Password.RequiredLength = 6;
      options.Password.RequiredUniqueChars = 0;
      options.Password.RequireNonAlphanumeric = false;
    })
    .AddRoleManager<RoleManager<Role>>()
    .AddUserManager<UserManager<User>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
    services.AddTransient(typeof(ILogger), typeof(Logger<Startup>));
    services.AddTransient<ISubjectService, SubjectService>();
    services.AddTransient<IGradeService, GradeService>();
    services.AddTransient<IGroupService, GroupService>();
    services.AddTransient<IStudentService, StudentService>();
    services.AddTransient<ITeacherService, TeacherService>();
    services.SeedData();
  }
}