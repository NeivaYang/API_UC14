using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class AtividadeRepository
    {
        private readonly ExoApiContext _contextDB;

        public AtividadeRepository(ExoApiContext context)
        {
            _contextDB = context;
        }

        public void Cadastrar(Atividade atividade)
        {
            _contextDB.Atividades.Add(atividade);
            _contextDB.SaveChanges();
        }

        public void Atualizar(int Id, Atividade atividade)
        {
            Atividade atividadeBuscada = _contextDB.Atividades.Find(Id);

            if (atividadeBuscada != null)
            {
                atividadeBuscada.IdProjeto = atividade.IdProjeto;
                atividadeBuscada.Nome = atividade.Nome;
                atividadeBuscada.Descricao = atividade.Descricao;
                atividadeBuscada.Dt_Inicio = atividade.Dt_Inicio;
                atividadeBuscada.Dt_Fim = atividade.Dt_Fim;

                _contextDB.Atividades.Update(atividadeBuscada);
                _contextDB.SaveChanges();
            }
        }

        public void Deletar(int Id)
        {
            Atividade atividadeBuscada = _contextDB.Atividades.Find(Id);

            if (atividadeBuscada != null)
            {
                _contextDB.Atividades.Remove(atividadeBuscada);
                _contextDB.SaveChanges();
            }
        }

        public Atividade BuscarPorId(int Id)
        {
            return _contextDB.Atividades.Find(Id); ;
        }

        public List<Atividade> Listar()
        {
            return _contextDB.Atividades.ToList();
        }
    }
}
