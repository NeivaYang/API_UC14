namespace ExoApi.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public int Status { get; set; }
        public DateTime Dt_Inicio { get; set; }
        public DateTime Dt_Fim { get; set; }

    }
}
