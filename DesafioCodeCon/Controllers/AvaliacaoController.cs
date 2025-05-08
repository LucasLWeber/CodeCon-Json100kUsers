using DesafioCodeCon.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioCodeCon.Controllers
{
    [Route("/evaluation")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public List<string> _endPoints { get; set; } = new ()
        {
            "/superusers",
            "/top-countries",
            "/team-insights",
            "/active-users-per-day"
        };

        public AvaliacaoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5164");
        }

        [HttpGet]
        public async Task<IActionResult> AvaliacaoEndPoints()
        {
            var results = new List<EvaluationDto>();

            foreach (var ep in _endPoints)
            {
                var stopWatch = Stopwatch.StartNew();

                HttpResponseMessage response = null!;

                try
                {
                    response = await _httpClient.GetAsync(ep);
                    stopWatch.Stop();

                    results.Add(new EvaluationDto
                    {
                        EndPoint = ep,
                        StatusCode = response.StatusCode,
                        TimeMs = (int) stopWatch.ElapsedMilliseconds,
                        ValidResponse = response.IsSuccessStatusCode
                    });
                }
                catch
                {
                    stopWatch.Stop();
                    results.Add(new EvaluationDto
                    {
                        StatusCode = response.StatusCode,
                        TimeMs = (int)stopWatch.ElapsedMilliseconds,
                        ValidResponse = false
                    });
                }
            }

            return Ok(results);
        }
    }
}
