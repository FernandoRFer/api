namespace API.DTO
{
    public class Music : MusicaId
    {
        public string NomeMusica { get; set; }
        public string Cifra { get; set; }

        
        
        public Music(int id ,string nomeMusica, string cifra) : base(id)
        {
            NomeMusica = nomeMusica;
            Cifra = cifra;
        }

        
    }
}
