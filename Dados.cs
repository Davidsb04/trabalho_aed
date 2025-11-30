
using System.Text;

namespace PlayerMusical
{
    static class Dados
    {
        public static Dictionary<string, Musica> Catalogo = new Dictionary<string, Musica>();
        public static List<Playlist> ListaPlaylists = new List<Playlist>();

        public static void InicialiazarDadosCSV()
        {
            string linha;

            try
            {
                StreamReader arq = new StreamReader("músicas.csv", Encoding.Latin1);

                linha = arq.ReadLine();

                while (linha != null)
                {
                    linha = arq.ReadLine();
                    linha = linha.Replace("\"", "");
                    string[] coluna = linha.Split(';');
                    Musica musica = new Musica(coluna[0], coluna[1], coluna[2], int.Parse(coluna[3]));
                    Catalogo.Add(musica.Chave, musica);

                    linha = arq.ReadLine();
                }

                arq.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static void ExibirCatalogo()
        {
            foreach (string chave in Catalogo.Keys)
                Console.WriteLine(chave);
        }

        public static bool BuscarMusica(string chave, out Musica musica)
        {
            if(Catalogo.TryGetValue(chave, out musica))
                return true;
            return false;
        }

        public static void CriarPlaylist(string nomePlaylist)
        {
            if (!BuscarPlaylist(nomePlaylist))
            {
                Playlist playlist = new Playlist(nomePlaylist);

                ListaPlaylists.Add(playlist);
            }
            else
                Console.WriteLine("Essa playlist já existe.");                
        }

        public static bool BuscarPlaylist(string nomePlaylist)
        {
            if (ListaPlaylists.Any(p => p.Nome == nomePlaylist))
                return true;
            return false;
        }

        public static Playlist RetornarPlaylist(string nomePlaylist)
        {
            return ListaPlaylists.FirstOrDefault(p => p.Nome == nomePlaylist);
        }


        public static void ExibirPlaylists()
        {
            if (ListaPlaylists.Count == 0)
                Console.WriteLine("Nenhuma playlist encontrada.");
            else
            {
                foreach (Playlist item in ListaPlaylists)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        public static void InserirMusicaPlaylist(string nomePlaylist, string nomeMusica)
        {
            if (BuscarMusica(nomeMusica, out Musica musica))
            {
                Playlist playlistSelecionada = RetornarPlaylist(nomePlaylist);
                playlistSelecionada.InserirMusica(musica);

            }
            else
            {
                Console.WriteLine("Música não encontrada.");
            }
        }
    }


}
