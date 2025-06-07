using FctTestTask.Domain.ViewModels.Link;
using FctTestTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FctTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkController : Controller
    {
        private readonly ILinkService _linkService;
        private readonly ILogger<LinkController> _logger;

        public LinkController(ILogger<LinkController> logger, ILinkService linkService)
        {
            _linkService = linkService;
            _logger = logger;
        }
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<LinkShortViewModel> Create(LinkLongViewModel model)
        {
            return;
        }
    }
}
