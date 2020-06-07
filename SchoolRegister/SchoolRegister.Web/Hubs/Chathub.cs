using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SchoolRegister.BLL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.ViewModels.VMs;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Web.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _dbContext;

        public ChatHub(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SendMessageAll(MessageVm message)
        {
            message.Author = Context.User.Identity.Name;
            Clients.All.SendAsync("ShowMessage", message);
        }

        public void SendMessageToUser(MessageVm message)
        {
            message.Author = Context.User.Identity.Name;
            var rescipient = _dbContext.Users.FirstOrDefault(u => u.UserName == message.RecipientName);
            if (rescipient != null)
            {
                Clients.User(rescipient.Id.ToString()).SendAsync("ShowMessage", message);
            }
        }

        public void SendMessageToGroup(MessageVm message)
        {
            message.Author = Context.User.Identity.Name;
            Clients.Group(message.RecipientName).SendAsync("ShowMessage", message);
        }

        private void SetGroups()
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == Context.User.Identity.Name);
            if (user is Student student)
            {
                Groups.AddToGroupAsync(Context.ConnectionId, student.Group.Name);
            }
        }
        public override Task OnConnectedAsync()
        {
            SetGroups();
            return base.OnConnectedAsync();
        }
    }
}
