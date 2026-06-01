using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Kolokwium.Services.Interfaces;
using Kolokwium.Services.DTO.Author;
using Kolokwium.Web.ViewModels.Author;

namespace Kolokwium.Web.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(
          IAuthorService authorService,
          ILogger<AuthorController> logger,
          IMapper mapper,
          IStringLocalizer localizer)
          : base(logger, mapper, localizer)
        {
            _authorService = authorService;

        }

       /* public async Task<IActionResult> Index()
        {
            var authorsDto = await _authorService.GetAllAsync();

            // Mapper od razu zamienia List<AuthorDto> na List<IndexAuthorViewModel>
            var viewModel = Mapper.Map<List<IndexAuthorViewModel>>(authorsDto);

            return View(viewModel); // Przekazujemy LISTĘ obiektów
        }*/

        public async Task<IActionResult> Index()
        {
            var authorsDto = await _authorService.GetAllAsync();

            var viewModel = new IndexAuthorViewModel
            {
                Authors = authorsDto
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var authorDto = await _authorService.GetByIdAsync(id); 
            if (authorDto == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = Mapper.Map<DetailsAuthorViewModel>(authorDto);
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAuthorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var dto = Mapper.Map<CreateAuthorDto>(model);
                await _authorService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(model);
            }
        }

             public async Task<IActionResult> Edit(int id)
        {
            var dto = await _authorService.GetByIdAsync(id);
            if (dto == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = Mapper.Map<EditAuthorViewModel>(dto);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAuthorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var dto = Mapper.Map<UpdateAuthorDto>(model);
                var success = await _authorService.UpdateAsync(dto);

                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
            }
            return View(model);
        }
    }
    
}
