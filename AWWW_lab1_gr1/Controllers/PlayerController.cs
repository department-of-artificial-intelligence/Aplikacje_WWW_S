using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class PlayerController : Controller
    {
        private IList<Player>? _players;
        public PlayerController()
        {
            _players = new List<Player>() {
                new Player()
                {
                  Id = 1,
                  FirstName = "Jan",
                  LastName = "Kowalski",
                  Country="Poland",
                  DateOfBirth = new DateTime(1999, 12, 1),
                },
                new Player()
                {
                  Id = 2,
                  FirstName = "Anna",
                  LastName = "Nowicka",
                  Country="Poland",
                  DateOfBirth = new DateTime(2001, 5, 15),
                },
                new Player()
                {
                  Id = 3,
                  FirstName = "Piotr",
                  LastName = "Wieczorek",
                  Country="Poland",
                  DateOfBirth = new DateTime(1998, 3, 8),
                }
            };
        }
        public IActionResult Players()
        {
            ViewBag.Title = "Player list";

            if (_players == null) { return View(); }

            ViewBag.PlayersCount = _players.Count;

            var playersName = new List<string>();
            foreach (var player in _players)
            {
                playersName.Add(player.FirstName + " " + player.LastName);
            }
            ViewBag.PlayersName = playersName;

            return View();
        }

        public IActionResult Index(int id = 1)
        {
            ViewBag.Title = "Player Info";

            if (_players != null && _players.Count > id)
            {
                return View(_players[id]);
            }
            return View();
        }
    }
}
