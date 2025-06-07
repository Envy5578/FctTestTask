using FctTestTask.Domain.ViewModels.Link;
using FctTestTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FctTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkController : Controller
    {
        private readonly ILinkService _linkService;
        private readonly ILogger<LinkController> _logger;

        public LinkController(ILogger<LinkController> logger, ILinkService linkService)
        {
            _linkService = linkService;
            _logger = logger;
        }

        /// <summary>
        /// Создание короткой ссылки
        /// </summary>
        /// <param name="model">LinkLongViewModel object</param>
        /// <returns>Returns LinkLongViewModel</returns>
        [HttpPost]
        public async Task<IActionResult> Create(LinkLongViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _linkService.Create(model);
            return Json(new {data = result.Data});
        }

        /// <summary>
        /// Получение оригинальной ссылки
        /// </summary>
        /// <param name="model">LinkShortViewModel object</param>
        /// <returns>Returns LinkLongViewModel</returns>
        [HttpGet]
        public async Task<IActionResult> GetLinkLong(LinkShortViewModel model)
        {
            var result = await _linkService.GetLink(model);
            if(result.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return Json(new { data = result.Data });
            }
            else if (result.StatusCode == Domain.Enum.StatusCode.LinkNotFound)
            {
                return NotFound();   
            }
            return BadRequest(new {data = result.Data});
        }

    }
}
