using System.Text;

namespace PlayerMusical
{

	internal class Program
	{
		static void Main(string[] args)
		{
			Dados.InicialiazarDadosCSV();	

			bool executando = true;

			while (executando)
			{
				//Console.Clear();
				Console.WriteLine("===== MENU PRINCIPAL =====");
				Console.WriteLine("1 - Gerenciar Catálogo");
				Console.WriteLine("2 - Gerenciar Playlists");
				Console.WriteLine("3 - Reproduzir");
				Console.WriteLine("4 - Ver Histórico");
				Console.WriteLine("0 - Sair");
				Console.Write("Opção: ");

				string opcao = Console.ReadLine();

				Console.Clear();

				switch (opcao)
				{
					case "1":
						MenuCatalogo();
						break;

					case "2":
						MenuPlaylist();
						break;

					case "3":
						MenuReproducao();
						break;

					case "4":
						MenuHistorico();
						break;

					case "0":
						executando = false;
						break;

					default:
						break;
				}
			}
		}

		static void MenuCatalogo()
		{
			bool loop = true;

			while (loop)
			{
				//Console.Clear();
				Console.WriteLine("===== GERENCIAR CATÁLOGO =====");
				Console.WriteLine("1 - Exibir Catálogo");
				Console.WriteLine("2 - Buscar Música");
				Console.WriteLine("0 - Voltar");
				Console.Write("Opção: ");

				int opcao = int.Parse(Console.ReadLine());

				switch (opcao)
				{
					case 1:
						Dados.ExibirCatalogo();
						break;

					case 2:
						Console.Write("Digite o nome da música: ");
						string musicaBusca = Console.ReadLine();

						if (Dados.BuscarMusica(musicaBusca, out Musica musica))
                            MenuMusicaEncontrada(musicaBusca, musica);
                        else
                            Console.WriteLine("Nenhuma referência encontrada.");
                        break;
					case 0:
						loop = false;
							break;

					default:
						Console.WriteLine("Essa opção não existe.");
						
						 break;
				}
			}
		}

		static void MenuPlaylist()
		{
			bool loop = true;

			while (loop)
			{
				Console.WriteLine("===== PLAYLISTS =====");
				Console.WriteLine("1 - Criar Playlist");
				Console.WriteLine("2 - Selecionar Playlist");
				Console.WriteLine("3 - Exibir Playlists");
				Console.WriteLine("0 - Voltar");
				Console.Write("Opção: ");

				int opcao = int.Parse(Console.ReadLine());

				switch (opcao)
				{
					case 1:
						Console.Write("Digite o nome da playlist: ");
						string nomePlaylist = Console.ReadLine();

						Dados.CriarPlaylist(nomePlaylist);
						break;

					case 2:
                        Console.Write("Digite o nome da playlist: ");
						string playlistSelecionada = Console.ReadLine();

						if (Dados.BuscarPlaylist(playlistSelecionada))
                            MenuPlaylistSelecionada(playlistSelecionada);
						else
							Console.WriteLine("Essa playlist não existe.");							
						break;

					case 3:
						Dados.ExibirPlaylists();
						break;
					case 0:
						loop = false;
						break;
				}
			}
		}

		static void MenuReproducao()
		{
			bool loop = true;

			while (loop)
			{
				Console.Clear();
				Console.WriteLine("===== REPRODUÇÃO =====");
				Console.WriteLine("1 - Selecionar Playlist para Reproduzir");
				Console.WriteLine("2 - Ver Fila de Reprodução");
				Console.WriteLine("3 - Reproduzir Próxima Música");
				Console.WriteLine("4 - Adicionar Música à Fila");
				Console.WriteLine("0 - Voltar");
				Console.Write("Opção: ");

				string opcao = Console.ReadLine();

				if (opcao == "0") loop = false;
			}
		}

		static void MenuHistorico()
		{
			bool loop = true;

			while (loop)
			{
				Console.Clear();
				Console.WriteLine("===== HISTÓRICO =====");
				Console.WriteLine("1 - Exibir Últimas Músicas Tocadas");
				Console.WriteLine("2 - Voltar uma Música");
				Console.WriteLine("0 - Voltar");
				Console.Write("Opção: ");

				string opcao = Console.ReadLine();

				if (opcao == "0") loop = false;
			}
		}

		static void MenuMusicaEncontrada(string nomeMusica, Musica musica)
		{
            Console.WriteLine($"===== {nomeMusica} =====");
            Console.WriteLine("1 - Exibir Últimas Músicas Tocadas");
            Console.WriteLine("2 - Voltar uma Música");
            Console.WriteLine("0 - Voltar");
            Console.Write("Opção: ");

            int opcao = int.Parse(Console.ReadLine());
        }

		static void MenuPlaylistSelecionada(string nomePlaylist)
		{
            bool loop = true;

            while (loop)
            {
                Console.WriteLine($"===== PLAYLIST {nomePlaylist.ToUpper()} =====");
                Console.WriteLine("1 - Reproduzir");
                Console.WriteLine("2 - Adicionar Música");
                Console.WriteLine("3 - Buscar Música");
                Console.WriteLine("4 - Remover Música");
                Console.WriteLine("0 - Voltar");
                Console.Write("Opção: ");

                int opcao = int.Parse(Console.ReadLine());

				switch (opcao)
				{
					case 1:
						break;
					case 2:
						Console.Write("Digite o nome da música: ");
						string nomeMusica = Console.ReadLine();

						Dados.InserirMusicaPlaylist(nomePlaylist, nomeMusica);
						break;
					case 0:
						loop = false;
						break;
				}
			}
		}		

	}
}
