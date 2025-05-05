public class TeamController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeamController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        ViewBag.Leagues = new SelectList(_context.Leagues, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Team team)
    {
        if (ModelState.IsValid)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        ViewBag.Leagues = new SelectList(_context.Leagues, "Id", "Name", team.LeagueId);
        return View(team);
    }
}