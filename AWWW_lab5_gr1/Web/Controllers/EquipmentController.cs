using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Equipment;
using Services.Interfaces;
using Web.ViewModels.Equipment;

namespace Web.Controllers
{
    public class EquipmentController : BaseController
    {
        private readonly IEquipmentService _service;
        private readonly IMapper _mapper;

        public EquipmentController(IEquipmentService service, IMapper mapper, IWebHostEnvironment env) : base(env)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dtos = await _service.GetAllAsync();
            return View(_mapper.Map<List<EquipmentListItemViewModel>>(dtos));
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(_mapper.Map<EquipmentDetailsViewModel>(dto));
        }

        public IActionResult Create() => View(new CreateEquipmentViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEquipmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _service.CreateAsync(_mapper.Map<CreateEquipmentDto>(model));
            SetSuccessMessage("Wyposa¿enie zosta³o dodane.");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(_mapper.Map<EditEquipmentViewModel>(dto));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEquipmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var success = await _service.UpdateAsync(_mapper.Map<UpdateEquipmentDto>(model));
            if (success) { SetSuccessMessage("Wyposa¿enie zaktualizowane."); return RedirectToAction(nameof(Index)); }
            SetErrorMessage("B³¹d podczas aktualizacji.");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(_mapper.Map<DeleteEquipmentViewModel>(dto));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (success) SetSuccessMessage("Wyposa¿enie usuniête.");
            else SetErrorMessage("Nie uda³o siê usun¹æ wyposa¿enia.");
            return RedirectToAction(nameof(Index));
        }
    }
}