using Microsoft.AspNetCore.Mvc;
using Model;
using Services.Interfaces;
using Web.ViewModels.Building;

namespace Web.Controllers {
	public class BuildingsController : BaseController {
		private readonly IBuildingService _bSrv;
		private readonly IRoomService _rSrv;

		public BuildingsController(
			IBuildingService bSrv,
			IRoomService rSrv,
			IWebHostEnvironment env) 
		: base(env) 
		{
			_bSrv = bSrv;
			_rSrv = rSrv;
		}

		public async Task<IActionResult> Index() {
			BuildingsViewModel model = new BuildingsViewModel();

			model.Buildings = await _bSrv.GetAllAsync();

			return View(model);
		}
	}
}
