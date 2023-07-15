using PoupeMais.Dao;
using PoupeMais.Models;

namespace PoupeMais.Services
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _contexto;

        public UsuarioService(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }
        public void AtualizarUsuario(Usuario usuario)
        {
            var user = _contexto.Usuarios.First(u => u.Id == usuario.Id);
            user.Nome = usuario.Nome;
            user.Senha = usuario.Senha;
            user.Email = usuario.Email;
            _contexto.SaveChanges();
        }

        public Usuario BuscarUsuarioPorEmail(string email) => _contexto.Usuarios.FirstOrDefault(u => u.Email == email);
        public Usuario BuscarUsuarioPorId(int id) => _contexto.Usuarios.FirstOrDefault(u => u.Id == id);

    }
}
