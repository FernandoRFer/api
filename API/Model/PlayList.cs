namespace API.Model
{
    public class PlayList 
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime Alteracao { get; set; }

    }
}
