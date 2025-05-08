using DesafioCodeCon.Models;

namespace DesafioCodeCon.Repositories
{
    public class UsuarioRepository
    {
        private readonly List<Usuario> _db = new();

        public void SaveAll(IEnumerable<Usuario> usuarios)
        {
            lock (_db)
            {
                _db.Clear();
                _db.AddRange(usuarios);
            }
        }

        public IEnumerable<Usuario> GetAll() => _db;
    }

}
