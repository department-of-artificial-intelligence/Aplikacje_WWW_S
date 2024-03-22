
using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class AuthorController : Controller {
    MyDbContext DbContext;
    public AuthorController (MyDbContext dbContext){
        this.DbContext = dbContext;
    } 
    

}