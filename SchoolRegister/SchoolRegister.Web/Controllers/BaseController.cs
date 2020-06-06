using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace SchoolRegister.Web.Controllers
{
    public class BaseController<TController> : Controller
    {
        protected readonly IStringLocalizer<TController> _localizer;
        protected readonly ILogger _logger;

        public BaseController(IStringLocalizer<TController> localizer, ILoggerFactory loggerFactory)
        {
            _localizer = localizer;
            _logger = loggerFactory.CreateLogger(GetType());
        }
    }
}