using System.Text;

namespace PlayerMusical
{

	internal class Program
	{
		static void Main(string[] args)
		{
			Dados.InicialiazarDadosCSV();
			Dados.InserirMusicasArvore();
			Dados.PreencherVetorMusicas();



            bool executando = true;

			while (executando)
			{
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
				Console.WriteLine("===== GERENCIAR CATÁLOGO =====");
				Console.WriteLine("1 - Exibir Catálogo");
				Console.WriteLine("2 - Buscar Música");
                Console.WriteLine("3 - Buscar Músicas por Gênero");
                Console.WriteLine("4 - Ordernar Catálogo");
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
					case 3:
                        Console.Write("Digite o gênero: ");
                        string generoBusca = Console.ReadLine();

						Dados.PesquisarPorGenero(generoBusca);
                        break;
					case 4:
                        Console.WriteLine("1 - Ordenar por Ordem Alfabética");
                        Console.WriteLine("2 - Ordernar por Tempo de Duração");
						Console.Write("Opção: ");

						int opcaoOrdenacao = int.Parse(Console.ReadLine());

						if (opcaoOrdenacao == 1)
							Dados.OrdenarMusica("Titulo");
						else
							Dados.OrdenarMusica("Duracao");
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
				Console.WriteLine("===== REPRODUÇÃO =====");
				Console.WriteLine("1 - Selecionar Playlist para Reproduzir");
				Console.WriteLine("2 - Ver Fila de Reprodução");
				Console.WriteLine("3 - Reproduzir Próxima Música");
				Console.WriteLine("4 - Adicionar Música à Fila");
				Console.WriteLine("0 - Voltar");
				Console.Write("Opção: ");

				int opcao = int.Parse(Console.ReadLine());

				switch (opcao)
				{
					case 1:
						Console.Write("Digite o nome da playlist: ");
						string nomePlaylist = Console.ReadLine();
						Dados.CarregarPlaylist(nomePlaylist);
						break;

					case 2:
						Dados.ExibirFila();
						break;
					case 3:
						Dados.ReproduzirProxima();
						break;
					case 4:
						Console.Write("Digite o nome da música: ");
						string musicaBusca = Console.ReadLine();

						if (Dados.BuscarMusica(musicaBusca, out Musica musica)){
							Dados.AdicionarMusicaFila(musica);
						}
						else {
							Console.WriteLine("Nenhuma referência encontrada.");
						}
							
						break;
					case 0:
						loop = false;
						break;
				}
			}
		}

		static void MenuHistorico()
		{
			bool loop = true;

			while (loop)
			{
				Console.WriteLine("===== HISTÓRICO =====");
				Console.WriteLine("1 - Exibir Últimas Músicas Tocadas");
				Console.WriteLine("2 - Voltar uma Música");
				Console.WriteLine("0 - Voltar");
				Console.Write("Opção: ");

				int opcao = int.Parse(Console.ReadLine());

				switch (opcao)
				{
					case 1:
						Dados.ImprimirHistorico();
						break;
					case 2:
						Dados.VoltarMusica();
						break;
					case 0:
						loop = false;
						break;
				}
			}
		}

		static void MenuMusicaEncontrada(string nomeMusica, Musica musica)
		{
            bool loop = true;

			while (loop)
			{
				Console.WriteLine($"===== {nomeMusica} =====");
				Console.WriteLine("1 - Reproduzir");
				Console.WriteLine("2 - Adicionar a uma playlist");
				Console.WriteLine("0 - Voltar");
				Console.Write("Opção: ");

				int opcao = int.Parse(Console.ReadLine());

				switch (opcao)
				{
					case 1:
						Dados.ReproduzirMusica(musica);
						break;
					case 2:
						Console.Write("Digite o nome da playlist: ");
						string playlistSelecionada = Console.ReadLine();

						Dados.InserirMusicaPlaylist(playlistSelecionada, nomeMusica);
						break;
					case 0:
						loop = false;
						break;
					default:
						Console.WriteLine("Opção inexistente.");
						break;

				}
			}

		}

		static void MenuPlaylistSelecionada(string nomePlaylist)
		{
            bool loop = true;

            while (loop)
            {
                Console.WriteLine($"===== PLAYLIST {nomePlaylist.ToUpper()} =====");
                Console.WriteLine("1 - Reproduzir");
                Console.WriteLine("2 - Adicionar Música");
                Console.WriteLine("3 - Exibir Músicas");
                Console.WriteLine("4 - Buscar Música");
                Console.WriteLine("5 - Remover Música");
                Console.WriteLine("0 - Voltar");
                Console.Write("Opção: ");

                int opcao = int.Parse(Console.ReadLine());

				switch (opcao)
				{
					case 1:
						break;
					case 2:
						Console.Write("Digite o nome da música: ");
						string nomeMusicaInserir = Console.ReadLine();

						Dados.InserirMusicaPlaylist(nomePlaylist, nomeMusicaInserir);
						break;
					case 3:
						Dados.ExibirMusicasPlaylist(nomePlaylist);
						break;
					case 4:
						Console.Write("Digite o nome da música: ");
						string nomeMusicaBuscar = Console.ReadLine();
						if (Dados.BuscarMusicaPlaylist(nomePlaylist, nomeMusicaBuscar))
						{
                            Console.WriteLine($"===== MÚSICA {nomeMusicaBuscar.ToUpper()} =====");
                            Console.WriteLine("1 - Mover para cima");
                            Console.WriteLine("2 - Mover para baixo");
                            Console.Write("Opção: ");

							int opcaoMusica = int.Parse(Console.ReadLine());

							switch (opcaoMusica)
							{
								case 1:
									Dados.MoverMusicaPlaylist(nomePlaylist, nomeMusicaBuscar, "Cima");
									break;
								case 2:
									Dados.MoverMusicaPlaylist(nomePlaylist, nomeMusicaBuscar, "Baixo");
									break;
								default:
									Console.WriteLine("Opção inválida.");
									break;
							}
                        }
						break;

					case 5:
                        Console.Write("Digite o nome da música: ");
                        string nomeMusicaRemover = Console.ReadLine();

						Dados.RemoverMusicaPlaylist(nomePlaylist, nomeMusicaRemover);
                        break;
					case 0:
						loop = false;
						break;
				}
			}
		}		

	}
}
