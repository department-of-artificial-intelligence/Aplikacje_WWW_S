using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Kolokwium.Services.Interfaces;
using Kolokwium.Services.DTO.Book;
using Kolokwium.Web.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public BookController(
            IBookService bookService,
            IAuthorService authorService,
            IPublisherService publisherService,
            ILogger<BookController> logger,
            IMapper mapper,
            IStringLocalizer localizer)
            : base(logger, mapper, localizer)
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        // GET: /Book/Index
        public async Task<IActionResult> Index()
        {
            var booksDto = await _bookService.GetAllAsync();
            var viewModel = Mapper.Map<List<IndexBookViewModel>>(booksDto);
            return View(viewModel);
        }

        // GET: /Book/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var bookDto = await _bookService.GetByIdAsync(id);
            if (bookDto == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = Mapper.Map<DetailsBookViewModel>(bookDto);
            return View(viewModel);
        }

        // GET: /Book/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateBookViewModel();

            // Ładowanie wydawnictw (1:N)
            var publishers = await _publisherService.GetAllAsync();
            viewModel.Publishers = publishers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

            // Ładowanie autorów (M:N)
            var authors = await _authorService.GetAllAsync();
            viewModel.Authors = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FullName
            }).ToList();

            return View(viewModel);
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Przeładowanie list w przypadku błędu walidacji
                var publishers = await _publisherService.GetAllAsync();
                viewModel.Publishers = publishers.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();

                var authors = await _authorService.GetAllAsync();
                viewModel.Authors = authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.FullName
                }).ToList();

                return View(viewModel);
            }

            try
            {
                var dto = Mapper.Map<CreateBookDto>(viewModel);
                await _bookService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(viewModel);
            }
        }

        // GET: /Book/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _bookService.GetByIdAsync(id); // Zwraca BookDetailsDto
            if (dto == null)
            {
                return RedirectToAction(nameof(Index));
            }

            // Mapowanie z BookDetailsDto do EditBookViewModel (pamiętaj o .Select(a => a.Id) w profilu)
            var viewModel = Mapper.Map<EditBookViewModel>(dto);

            // Ładowanie wydawnictw pod selecta
            var publishers = await _publisherService.GetAllAsync();
            viewModel.Publishers = publishers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

            // Ładowanie autorów pod selecta
            var authors = await _authorService.GetAllAsync();
            viewModel.Authors = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FullName
            }).ToList();

            return View(viewModel);
        }

        // POST: /Book/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBookViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Ponowne ładowanie list w przypadku nieudanej walidacji
                var publishers = await _publisherService.GetAllAsync();
                viewModel.Publishers = publishers.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();

                var authors = await _authorService.GetAllAsync();
                viewModel.Authors = authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.FullName
                }).ToList();

                return View(viewModel);
            }

            try
            {
                var dto = Mapper.Map<UpdateBookDto>(viewModel);
                var success = await _bookService.UpdateAsync(dto);

                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                // Tutaj opcjonalnie logowanie błędu
            }

            return View(viewModel);
        }
    }
}