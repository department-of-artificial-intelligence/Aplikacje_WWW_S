using Kolokwium.Model.DataModels;

namespace Kolokwium.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserVm> GetUsers();

        public UserVm GetUser(int id);

        public void AddOrUpdateUser(UserVm userVm);
    }
}