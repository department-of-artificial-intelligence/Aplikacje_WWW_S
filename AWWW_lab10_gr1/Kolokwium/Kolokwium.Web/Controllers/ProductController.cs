using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using AutoMapper;
using System.Threading.Tasks;
using Kolokwium.Services.Interfaces;
using Kolokwium.Services.DTO.Product;
using Kolokwium.ViewModel.VM.Product;

namespace Kolokwium.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService,
            ILogger<ProductController> logger,
            IMapper mapper,
            IStringLocalizer<ProductController> localizer) : base(logger, mapper, localizer)
        {
            _productService = productService;
        }

        // --- 1. WYŚWIETLANIE LISTY ---
        public async Task<IActionResult> Index()
        {
            var dtos = await _productService.GetAllAsync();
            var vms = Mapper.Map<IEnumerable<ProductVm>>(dtos);
            return View(vms);
        }

        // --- 2. FORMULARZ DODAWANIA (Wyświetlenie) ---
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateProductVm());
        }

        // --- 3. FORMULARZ DODAWANIA (Zapis do bazy) ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var dto = Mapper.Map<CreateProductDto>(vm);
            
            await _productService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
}

        // --- 4. BEZPOŚREDNIE USUWANIE (Z przycisku w Index.cshtml) ---
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            
            if (result)
            {
                TempData["Success"] = "Produkt został usunięty!";
            }
            else
            {
                TempData["Error"] = "Wystąpił błąd lub produkt nie istnieje.";
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}