using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Equipment;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.Equipment;

namespace Web.Controllers
{
    public class EquipmentController : BaseController
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IMapper _mapper;

        public EquipmentController(
            IEquipmentService equipmentService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var dtos = await _equipmentService.GetAllAsync();
            var viewModels = _mapper.Map<IList<EquipmentViewModel>>(dtos);
            return View(viewModels);
        }

        // GET: Equipments/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _equipmentService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<DetailsEquipmentViewModel>(dto);
            return View(viewModel);
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            return View(new CreateEquipmentViewModel());
        }

        // POST: Equipments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEquipmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<CreateEquipmentDto>(model);
            await _equipmentService.CreateAsync(dto);

            SetSuccessMessage("Element wyposażenia został utworzony.");
            return RedirectToAction(nameof(Index));
        }

        // GET: Equipments/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _equipmentService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<EditEquipmentViewModel>(dto);
            return View(model);
        }

        // POST: Equipments/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEquipmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<UpdateEquipmentDto>(model);
            var result = await _equipmentService.UpdateAsync(dto);

            if (!result)
            {
                return NotFound();
            }

            SetSuccessMessage("Wyposażenie zostało zaktualizowane.");
            return RedirectToAction(nameof(Index));
        }

        // GET: Equipments/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _equipmentService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<EquipmentViewModel>(dto);
            return View(model);
        }

        // POST: Equipments/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _equipmentService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            SetSuccessMessage("Element wyposażenia został usunięty.");
            return RedirectToAction(nameof(Index));
        }
    }
}