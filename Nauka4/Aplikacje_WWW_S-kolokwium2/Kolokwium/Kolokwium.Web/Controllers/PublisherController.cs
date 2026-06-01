using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Kolokwium.Services.Interfaces;
using Kolokwium.Services.DTO.Publisher;
using Kolokwium.Services.DTO.Book;
using Kolokwium.Web.ViewModels.Publisher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kolokwium.Web.Controllers
{
    public class PublisherController : BaseController
    {
        private readonly IPublisherService _publisherService;
        private readonly IBookService _bookService; // POPRAWIONO: Prawidłowy interfejs

        public PublisherController(
            IPublisherService publisherService,
            IBookService bookService, // POPRAWIONO: Dodano do konstruktora
            ILogger<PublisherController> logger,
            IMapper mapper,
            IStringLocalizer localizer)
            : base(logger, mapper, localizer)
        {
            _publisherService = publisherService;
            _bookService = bookService; // POPRAWIONO: Przypisanie pola
        }

        // GET: /Publisher/Index
        public async Task<IActionResult> Index()
        {
            // Pobieramy dane z obu serwisów
            var publishersDto = await _publisherService.GetAllAsync();
            var booksDto = await _bookService.GetAllAsync();

            // POPRAWIONO: Przypisujemy kolekcje bezpośrednio, bez Mappera, bo typy w DTO i VM są takie same
            var viewModel = new IndexPublisherViewModel
            {
                Publishers = publishersDto,
                Books = booksDto
            };

            return View(viewModel);
        }

        // GET: /Publisher/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: /Publisher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePublisherViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var dto = Mapper.Map<PublisherDto>(model);
                await _publisherService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(model);
            }

            /*if (!ModelState.IsValid) return View(model);

            // USUŃ CHWILOWO TRY-CATCH, ABY ZOBACZYĆ BŁĄD NA EKRANIE:
            var dto = Mapper.Map<PublisherDto>(model);
            await _publisherService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));*/
        }
    }
}