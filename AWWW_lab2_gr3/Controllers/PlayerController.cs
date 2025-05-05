public class PlayerController : Controller
{
    private readonly ApplicationDbContext _context;

    public PlayerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Player player)
    {
        if (ModelState.IsValid)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return View(player);
    }
}