using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;

public class ArticleController:Controller {
    public IActionResult Index(int id=1) {
        var articles = new List<Article> {
            new Article {
                ArticleId = 1,
                Title = "Artykuł 1", 
                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Vel commodi voluptates provident aut veniam exercitationem reiciendis nam ex similique cum nisi necessitatibus eum error iste, ipsam minus officia ipsa incidunt. Nemo repellendus deserunt unde fugiat at quae, hic ab vel earum quia laboriosam quas quos itaque quod laudantium temporibus eos dignissimos optio? Fugit recusandae repudiandae velit, aspernatur beatae quisquam commodi aut iste provident veritatis? Necessitatibus laboriosam blanditiis similique eligendi vel harum, dolorem hic placeat, voluptatem sunt asperiores iure incidunt enim ad nesciunt quas deleniti architecto molestiae sequi ea atque commodi perferendis qui error! Eos amet dolore earum id, doloremque ex?", 
                CreationDate = DateTime.Now
            }, 
            new Article {
                ArticleId = 2,
                Title = "Artykuł 2", 
                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Vel commodi voluptates provident aut veniam exercitationem reiciendis nam ex similique cum nisi necessitatibus eum error iste, ipsam minus officia ipsa incidunt. Nemo repellendus deserunt unde fugiat at quae, hic ab vel earum quia laboriosam quas quos itaque quod laudantium temporibus eos dignissimos optio? Fugit recusandae repudiandae velit, aspernatur beatae quisquam commodi aut iste provident veritatis? Necessitatibus laboriosam blanditiis similique eligendi vel harum, dolorem hic placeat, voluptatem sunt asperiores iure incidunt enim ad nesciunt quas deleniti architecto molestiae sequi ea atque commodi perferendis qui error! Eos amet dolore earum id, doloremque ex?", 
                CreationDate = DateTime.Now
            }, 
            new Article {
                ArticleId = 3,
                Title = "Artykuł 3", 
                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Vel commodi voluptates provident aut veniam exercitationem reiciendis nam ex similique cum nisi necessitatibus eum error iste, ipsam minus officia ipsa incidunt. Nemo repellendus deserunt unde fugiat at quae, hic ab vel earum quia laboriosam quas quos itaque quod laudantium temporibus eos dignissimos optio? Fugit recusandae repudiandae velit, aspernatur beatae quisquam commodi aut iste provident veritatis? Necessitatibus laboriosam blanditiis similique eligendi vel harum, dolorem hic placeat, voluptatem sunt asperiores iure incidunt enim ad nesciunt quas deleniti architecto molestiae sequi ea atque commodi perferendis qui error! Eos amet dolore earum id, doloremque ex?", 
                CreationDate = DateTime.Now
            }
            
        }; 
        return View(articles[id-1]); 
    }
}