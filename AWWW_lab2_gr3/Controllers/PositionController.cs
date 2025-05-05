public class PositionController : Controller
{
    private readonly ApplicationDbContext _context;

    public PositionController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Position position)
    {
        if (ModelState.IsValid)
        {
            _context.Positions.Add(position);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return View(position);
    }
}