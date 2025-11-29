namespace PlayerMusical
{
    internal class Musica
    {        
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }

        public string Chave {  get; set; }

        public Musica(string titulo, string artista, string genero, int duracao)
        {
            Titulo = titulo;
            Artista = artista;
            Genero = genero;
            Duracao = duracao;
            Chave = $"{titulo} {artista}";
        }
    }
}
