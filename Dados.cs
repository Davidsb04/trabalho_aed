
using System.Numerics;
using System.Text;

namespace PlayerMusical
{
    static class Dados
    {
        public static Dictionary<string, Musica> Catalogo = new Dictionary<string, Musica>();
        public static List<Playlist> ListaPlaylists = new List<Playlist>();
        public static ArvoreBinaria ArvoreGeneros = new ArvoreBinaria();
        public static Musica[] MusicaParaBusca = new Musica[Catalogo.Count];

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
            if (Catalogo.TryGetValue(chave, out musica))
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
                if (playlistSelecionada != null)
                    playlistSelecionada.InserirMusica(musica);
                else
                {
                    Console.WriteLine("Essa playlist não existe.");
                    return;
                }
                Console.WriteLine("Música inserida com sucesso.");
            }
            else
            {
                Console.WriteLine("Música não encontrada.");
            }
        }

        public static void ExibirMusicasPlaylist(string nomePlaylist)
        {
            Playlist playlist = RetornarPlaylist(nomePlaylist);
            playlist.ExibirMusicas();
        }

        public static void RemoverMusicaPlaylist(string nomePlaylist, string nomeMusica)
        {
            if (BuscarMusica(nomeMusica, out Musica musica))
            {
                Playlist playlist = ListaPlaylists.FirstOrDefault(p => p.Nome == nomePlaylist);
                playlist.RemoverMusica(musica);

                Console.WriteLine("Música removida com sucesso.");
            }
            else
                Console.WriteLine("Música não encontrada.");
        }

        public static bool BuscarMusicaPlaylist(string nomePlaylist, string nomeMusica)
        {
            if (BuscarMusica(nomeMusica, out Musica musica))
            {
                Playlist playlist = ListaPlaylists.FirstOrDefault(p => p.Nome == nomePlaylist);
                return playlist.BuscarMusica(nomeMusica);
            }
            return false;
        }

        public static void MoverMusicaPlaylist(string nomePlaylist, string nomeMusica, string direcao)
        {
            if (BuscarMusica(nomeMusica, out Musica musica))
            {
                Playlist playlist = ListaPlaylists.FirstOrDefault(p => p.Nome == nomePlaylist);
                if (direcao == "Cima")
                {
                    playlist.MoverMusicaCima(musica);
                }
                else
                {
                    playlist.MoverMusicaBaixo(musica);
                }
            }
            else
            {
                Console.WriteLine("Música não encontrada.");
            }
        }

        public static void PesquisarPorGenero(string genero)
        {
            List<Musica> musicasPorGenero = ArvoreGeneros.Pesquisar(genero);

            foreach (Musica musica in musicasPorGenero)
            {
                Console.WriteLine($"{musica.Titulo} - {musica.Artista}");
            }
        }

        public static void InserirMusicasArvore()
        {
            foreach (var musica in Catalogo.Values)
            {
                ArvoreGeneros.Inserir(musica);
            }
        }
        public static void PreencherVetorMusicas()
        {
            MusicaParaBusca = Catalogo.Values.ToArray();
        }

        public static void OrdenarMusica(string parametro)
        {
            if (parametro == "Duracao")
            {
                OrdenarMusicasDuracao(MusicaParaBusca, 0, MusicaParaBusca.Length - 1);
                foreach (Musica musica in MusicaParaBusca)
                {
                    Console.WriteLine($"{musica.Titulo} - {musica.Artista} - {musica.Duracao}");
                }
            }
            else
            {
                OrdenarMusicasTitulo(MusicaParaBusca, 0, MusicaParaBusca.Length - 1);
                foreach (Musica musica in MusicaParaBusca)
                {
                    Console.WriteLine($"{musica.Titulo} - {musica.Artista}");
                }

            }
        }

        private static void OrdenarMusicasTitulo(Musica[] array, int esq, int dir)
        {
            int i = esq, j = dir;
            string pivo = array[(esq + dir) / 2].Titulo;

            while (i <= j)
            {
                while (array[i].Titulo.CompareTo(pivo) < 0)
                    i++;

                while (array[j].Titulo.CompareTo(pivo) > 0)
                    j--;

                if (i <= j)
                {
                    Musica temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i++;
                    j--;
                }
            }

            if (esq < j)
                OrdenarMusicasTitulo(array, esq, j);

            if (i < dir)
                OrdenarMusicasTitulo(array, i, dir);
        }


        private static void OrdenarMusicasDuracao(Musica[] array, int esq, int dir)
        {
            int i = esq, j = dir, pivo = array[(esq + dir) / 2].Duracao;

            while (i <= j)
            {
                while (array[i].Duracao < pivo)
                    i++;
                while (array[j].Duracao > pivo)
                    j--;
                if (i <= j)
                {
                    Musica temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if(esq < j)
                OrdenarMusicasDuracao(array, esq, j);
            if (i < dir)
                OrdenarMusicasDuracao(array, i, dir);
        }
    }
}
