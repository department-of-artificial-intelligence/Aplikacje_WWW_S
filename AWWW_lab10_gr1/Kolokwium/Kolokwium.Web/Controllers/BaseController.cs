using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IStringLocalizer Localizer;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;

        // Konstruktor przyjmujący dokładnie 3 argumenty
        public BaseController(ILogger logger, IMapper mapper, IStringLocalizer localizer)
        {
            Localizer = localizer;
            Logger = logger;
            Mapper = mapper;
        }
    }
}