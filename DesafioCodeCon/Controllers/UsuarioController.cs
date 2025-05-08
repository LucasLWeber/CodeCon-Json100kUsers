using DesafioCodeCon.Dtos.Requests;
using DesafioCodeCon.Models;
using DesafioCodeCon.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DesafioCodeCon.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Carrega base de usuários in memory
        /// </summary>
        /// <returns>Retorna objeto com Quantidade de Usuários cadastrados, mensagem de Feedback e Status Code</returns>
        /// <response code="200">Base carregada com sucesso</response>
        /// <response code="400">Erros de validação do arquivo</response>
        /// <response code="500">Erros genéricos</response>
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] UploadUsuariosRequest request)
        {
            var file = request.File;

            if (file == null || file.Length == 0)
                return BadRequest("Arquivo inválido.");

            try
            {
                using var stream = file.OpenReadStream();

                var usuarios = await JsonSerializer.DeserializeAsync<List<Usuario>>(stream, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (usuarios == null || usuarios.Count == 0)
                    return BadRequest("Nenhum usuário encontrado no arquivo.");

                _usuarioRepository.SaveAll(usuarios);

                return Ok(new { message = "Arquivo recebido com sucesso", user_count = usuarios.Count });
            }
            catch (JsonException ex)
            {
                return BadRequest($"Erro ao desserializar o JSON: {ex.Message}");
            }
        }
    }
}
