using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ExoApiContext _contextDB;
        public UsuarioRepository(ExoApiContext context)
        {
            _contextDB = context; 
        }
        public void Cadastrar(Usuario usuario)
        {
            _contextDB.Usuarios.Add(usuario);
            _contextDB.SaveChanges();
        }

        public void Atualizar(int Id, Usuario usuario)
        {
            Usuario usuarioBuscado = _contextDB.Usuarios.Find(Id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;

                _contextDB.Usuarios.Update(usuarioBuscado);
                _contextDB.SaveChanges();
            }
        }
        
        public void Deletar(int Id)
        {
            Usuario usuarioBuscado = _contextDB.Usuarios.Find(Id);
            if (usuarioBuscado != null)
            {
                _contextDB.Usuarios.Remove(usuarioBuscado);
                _contextDB.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int Id)
        {
            return _contextDB.Usuarios.Find(Id);
        }

        public List<Usuario> Listar()
        {
            return _contextDB.Usuarios.ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
            return _contextDB.Usuarios.FirstOrDefault(us => us.Email == Email && us.Senha == Senha);
        }
    }
}
