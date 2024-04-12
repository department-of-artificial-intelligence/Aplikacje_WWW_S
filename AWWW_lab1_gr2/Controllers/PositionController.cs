using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;

public class PositionController: Controller {
    private readonly DatabaseContext _context; 
    private readonly ILogger _logger; 
    public PositionController(DatabaseContext context, ILogger logger){
        _context = context; 
        _logger = logger; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Pozycje"; 
        var positions = _context.Positions;
        return View(positions); 
    }

    public IActionResult Form() {
        ViewBag.Title = "Dodawanie pozycji"; 
        return View(); 
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(Position position) {
        if(ModelState.IsValid){

            _context.Positions.Add(position); 
            _context.SaveChanges(); 
            return RedirectToAction("Index"); 
        }
        return RedirectToAction("Index");  
    }

    [HttpPost]
    public IActionResult Delete(int id){
        try {
            var position = _context.Positions.Find(id); 
            if(position == null){
                throw new Exception("sus"); 
            }
            _context.Positions.Remove(position);
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index));  

        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw;
        }
    }
}