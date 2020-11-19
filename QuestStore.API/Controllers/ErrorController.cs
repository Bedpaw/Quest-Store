using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuestStore.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/Error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error() => Problem(
            title: "Internal Server Error",
            statusCode: StatusCodes.Status500InternalServerError);
    }
}
