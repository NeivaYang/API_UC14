using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoApiContext _contextDB;

        public ProjetoRepository(ExoApiContext context)
        {
            _contextDB = context;
        }

        public void Cadastrar(Projeto projeto)
        {
            _contextDB.Projetos.Add(projeto);
            _contextDB.SaveChanges();
        }

        public void Atualizar(int Id, Projeto projeto)
        {
            Projeto projetoBuscado = _contextDB.Projetos.Find(Id);

            if (projetoBuscado != null)
            {
                projetoBuscado.Descricao = projeto.Descricao;
                projetoBuscado.Nome = projeto.Nome;
                projetoBuscado.Dt_Inicio = projeto.Dt_Inicio;
                projetoBuscado.Dt_Fim = projeto.Dt_Fim;

                _contextDB.Projetos.Update(projetoBuscado);
                _contextDB.SaveChanges();
            }
        }

        public void Deletar(int Id)
        {
            Projeto projetoBuscado = _contextDB.Projetos.Find(Id);

            if (projetoBuscado != null)
            {
                _contextDB.Projetos.Remove(projetoBuscado);
                _contextDB.SaveChanges();
            }
        }

        public Projeto BuscarPorId(int Id)
        {
            return _contextDB.Projetos.Find(Id);
        }

        public List<Projeto> Listar()
        {
            return _contextDB.Projetos.ToList();
        }

    }
}
