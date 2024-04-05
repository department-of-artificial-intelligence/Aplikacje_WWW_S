using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AWWW_lab1_gr2.Controllers
{
    public class PlayerController : Controller
    {
        private readonly MyDbContext _dbContext;

        public PlayerController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    
    }
}
       