using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using AWWW_lab1_gr1.Models;
public class ArticleController:Controller{
    
    public IActionResult Article(){
        ViewBag.Title = "article ";
        
        return View();
    }
}