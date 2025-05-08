using DesafioCodeCon.Dtos.Responses;
using DesafioCodeCon.Models;
using DesafioCodeCon.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCodeCon.Controllers
{
    [Route("api")]
    [ApiController]
    public class AnalisesController : ControllerBase
    {
        private readonly AnalisesService _anaisesService;

        public AnalisesController(AnalisesService anaisesService) => _anaisesService = anaisesService;

        [HttpGet("/superusers")]
        public async Task<IActionResult> SuperUsuarios()
        {
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            var timeStamp = DateTime.UtcNow;
            var superUsuarios = _anaisesService.SuperUsuarios();

            stopWatch.Stop();

            return Ok(new GenericAnalisesResponse<List<Usuario>> {
                Data = superUsuarios,
                ExecutionTimeMs = (int) stopWatch.ElapsedMilliseconds,
                TimeStamp = timeStamp
            });
        }

        [HttpGet("/top-countries")]
        public async Task<IActionResult> TopCountries()
        {
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            var timeStamp = DateTime.UtcNow;
            var topCountries = _anaisesService.TopCountries();

            stopWatch.Stop();

            return Ok(new GenericAnalisesResponse<List<TopCountriesDto>>
            {
                Data = topCountries,
                ExecutionTimeMs = (int)stopWatch.ElapsedMilliseconds,
                TimeStamp = timeStamp
            });
        }

    }
}
