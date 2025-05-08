using DesafioCodeCon.Models;
using System.Collections.ObjectModel;

namespace DesafioCodeCon.Repositories
{
    public class UserRepository
    {
        private readonly Dictionary<Guid, Usuario> _db = new(); 

        public void SaveAll(IEnumerable<Usuario> usuarios)
        {
            foreach (var usuario in usuarios)
            {
                _db[usuario.Id] = usuario;
            }
        }

        public IEnumerable<Usuario> GetAll() => _db.Values;
    }
}
