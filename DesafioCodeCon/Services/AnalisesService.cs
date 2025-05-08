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

        public List<TeamInsightsDto> TeamInsights()
        {
            return _usuarioRepository.GetAll()
                .GroupBy(u => u.Equipe.Nome)
                .Select(g => new TeamInsightsDto
                    {
                        Nome = g.Key,
                        TotalMembros = g.Count(),
                        Lideres = g.Count(u => u.Equipe.Lider),
                        ProjetosConcluidos = g.SelectMany(u => u.Equipe.Projetos).Count(p => p.Concluido),
                        PctAtivo = g.Count(u => u.Ativo) * 100 / g.Count()
                    }
                )
                .ToList();
        }

        public List<ActiveUsersPerDayDto> DiaryLogins(int? min)
        {
            return _usuarioRepository.GetAll()
                .SelectMany(u => u.Logs)
                .Where(u => u.Acao == "login")
                .GroupBy(log => log.Data.Date)
                .Select(g => new ActiveUsersPerDayDto
                    {
                        Data = g.Key,
                        Total = g.Count(),
                    }
                )
                .Where(x => !min.HasValue || x.Total >= min)
                .OrderBy(x => x.Data.Date)
                .ToList();
        }
    }
}
