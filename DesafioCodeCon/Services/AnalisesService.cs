using DesafioCodeCon.Dtos.Responses;
using DesafioCodeCon.Models;
using DesafioCodeCon.Repositories;

namespace DesafioCodeCon.Services
{
    public class AnalisesService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public AnalisesService(UsuarioRepository usuarioRepository) =>  _usuarioRepository = usuarioRepository;

        public List<Usuario> SuperUsuarios()
        {
            return _usuarioRepository.GetAll()
                .Where(u => u.Score >= 900 && u.Ativo)
                .ToList();
        }
        
        public List<TopCountriesDto> TopCountries()
        {
            return SuperUsuarios()
                .GroupBy(u => u.Pais)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => new TopCountriesDto { 
                        Pais = g.Key,
                        Quantidade = g.Count() 
                    }
                )
                .ToList();
        }
    }
}
