namespace ExoApi.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public string Nome { get; set; } 
        public string Descricao { get; set; }
        public DateTime Dt_Inicio { get; set; }
        public DateTime Dt_Fim { get; set; }
    }
}
