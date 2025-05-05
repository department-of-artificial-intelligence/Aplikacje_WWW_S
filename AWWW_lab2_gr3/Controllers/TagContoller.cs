public class TagController : Controller
{
    private readonly ApplicationDbContext _context;

    public TagController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Tag tag)
    {
        if (ModelState.IsValid)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return View(tag);
    }
}