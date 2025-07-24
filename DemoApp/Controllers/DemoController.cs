
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private static int _contador = -1;

        [HttpGet]
        public IActionResult Get()
        {
            int nuevoValor = Interlocked.Increment(ref _contador);
            return Ok(nuevoValor);
        }
    }
}

