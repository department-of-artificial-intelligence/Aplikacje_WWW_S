using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class TagController:Controller{
    public IActionResult Index(int itemid){

        var tags = new List<Tag>{
            new Tag{
                Id = 1,
                Name = "Ekstremalne"
            },

            new Tag{
                Id = 2,
                Name = "Dla kobiet"
            },

            new Tag{
                Id = 3,
                Name = "Dla dzieci"
            }
        };
        return View(tags[itemid-1]);
    }
}