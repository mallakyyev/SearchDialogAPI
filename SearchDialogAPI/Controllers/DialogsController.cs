using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchDialogAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchDialogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DialogsController : ControllerBase
    {
       
        private readonly ILogger<DialogsController> _logger;
        private readonly IDialogsService _dialogsService;
        public DialogsController(ILogger<DialogsController> logger, IDialogsService dialogsService)
        {
            _logger = logger;
            _dialogsService = dialogsService;
        }

        /// <summary>
        /// Get dialog id that contains users in array "id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Guid</returns>
        /// <response code="200">Returns DialogId that match conditions</response>
        /// <response code="400">if request is empty or null</response>        
        [HttpGet("/GetDialog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Guid> Get([FromQuery] Guid [] id)
        {
            if (id != null && id.Length > 0)
            {
                return Ok(_dialogsService.GetRGDialog(id.ToList()));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
