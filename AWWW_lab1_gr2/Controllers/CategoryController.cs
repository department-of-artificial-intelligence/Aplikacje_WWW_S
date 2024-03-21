using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AWWW_lab1_gr2.Controllers
{
    public class CategoryController : Controller{
        public CategoryController( DatabaseContext databaseContext){
            asd = databaseContext;
        }
        private readonly DatabaseContext asd;
        public IActionResult Index(){
            return View(asd.Categories.ToList()!);
        }
    }
}