using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class MatchEventsController : Controller
    {
        private readonly MyDBContext _context;

        public MatchEventsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: MatchEvents
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.MatchEvents.Include(m => m.EventType).Include(m => m.Match).Include(m => m.MatchPlayer);
            return View(await myDBContext.ToListAsync());
        }

        // GET: MatchEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchEvent = await _context.MatchEvents
                .Include(m => m.EventType)
                .Include(m => m.Match)
                .Include(m => m.MatchPlayer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchEvent == null)
            {
                return NotFound();
            }

            return View(matchEvent);
        }

        // GET: MatchEvents/Create
        public IActionResult Create()
        {
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "Id", "Id");
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id");
            ViewData["MatchPlayerId"] = new SelectList(_context.MatchPlayers, "Id", "Id");
            return View();
        }

        // POST: MatchEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Minute,EventTypeId,MatchId,MatchPlayerId")] MatchEvent matchEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matchEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "Id", "Id", matchEvent.EventTypeId);
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id", matchEvent.MatchId);
            ViewData["MatchPlayerId"] = new SelectList(_context.MatchPlayers, "Id", "Id", matchEvent.MatchPlayerId);
            return View(matchEvent);
        }

        // GET: MatchEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchEvent = await _context.MatchEvents.FindAsync(id);
            if (matchEvent == null)
            {
                return NotFound();
            }
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "Id", "Id", matchEvent.EventTypeId);
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id", matchEvent.MatchId);
            ViewData["MatchPlayerId"] = new SelectList(_context.MatchPlayers, "Id", "Id", matchEvent.MatchPlayerId);
            return View(matchEvent);
        }

        // POST: MatchEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Minute,EventTypeId,MatchId,MatchPlayerId")] MatchEvent matchEvent)
        {
            if (id != matchEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchEventExists(matchEvent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "Id", "Id", matchEvent.EventTypeId);
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id", matchEvent.MatchId);
            ViewData["MatchPlayerId"] = new SelectList(_context.MatchPlayers, "Id", "Id", matchEvent.MatchPlayerId);
            return View(matchEvent);
        }

        // GET: MatchEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchEvent = await _context.MatchEvents
                .Include(m => m.EventType)
                .Include(m => m.Match)
                .Include(m => m.MatchPlayer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matchEvent == null)
            {
                return NotFound();
            }

            return View(matchEvent);
        }

        // POST: MatchEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matchEvent = await _context.MatchEvents.FindAsync(id);
            if (matchEvent != null)
            {
                _context.MatchEvents.Remove(matchEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchEventExists(int id)
        {
            return _context.MatchEvents.Any(e => e.Id == id);
        }
    }
}
