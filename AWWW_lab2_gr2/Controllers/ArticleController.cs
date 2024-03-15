using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

public class ArticleController : Controller{

    public IActionResult Index(int id=1)
        {
            var articles = new List<Article>{
                new Article{
                    Id = 1,
                    Title = "Artykuł 1",
                    Lead = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam imperdiet arcu est, in facilisis lacus. Nunc faucibus orci nec diam ullamcorper vitae hendrerit enim scelerisque. Fusce odio nulla, aliquet in auctor ac, congue quis turpis. Nunc et ipsum sem.",
                    CreationDate = DateTime.Now
                },
                new Article{
                    Id = 2,
                    Title = "Artykuł 2",
                    Lead = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam imperdiet arcu est, in facilisis lacus. Nunc faucibus orci nec diam ullamcorper vitae hendrerit enim scelerisque. Fusce odio nulla, aliquet in auctor ac, congue quis turpis. Nunc et ipsum sem.",
                    CreationDate = DateTime.Now
                },
                new Article{
                    Id = 3,
                    Title = "Artykuł 3",
                    Lead = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam imperdiet arcu est, in facilisis lacus. Nunc faucibus orci nec diam ullamcorper vitae hendrerit enim scelerisque. Fusce odio nulla, aliquet in auctor ac, congue quis turpis. Nunc et ipsum sem.",
                    CreationDate = DateTime.Now
                }
            };
            
            return View(articles[id-1]);
        }
}