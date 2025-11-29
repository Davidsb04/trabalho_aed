using System.Text;

namespace PlayerMusical
{

	internal class Program
	{
		static Dictionary<string, Musica> Catalogo = new Dictionary<string, Musica>();
		static void Main(string[] args)
		{
			InicialiazarDadosCSV();			

			bool executando = true;

			while (executando)
			{
				//Console.Clear();
				Console.WriteLine("===== MENU PRINCIPAL =====");
				Console.WriteLine("1 - Gerenciar Catálogo");
				Console.WriteLine("2 - Criar Playlist");
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
						foreach (string chave in Catalogo.Keys)
							Console.WriteLine(chave);
						break;

					case 2:
						Console.Write("Digite o nome da música: ");
						string musicaBusca = Console.ReadLine();

						if (Catalogo.TryGetValue(musicaBusca, out Musica musica))
                            MenuMusicaEncontrada();
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
				Console.Clear();
				Console.WriteLine("===== PLAYLISTS =====");
				Console.WriteLine("1 - Criar Playlist");
				Console.WriteLine("2 - Selecionar Playlist");
				Console.WriteLine("3 - Exibir Playlists");
				Console.WriteLine("0 - Voltar");
				Console.Write("Opção: ");

				string opcao = Console.ReadLine();

				if (opcao == "0") loop = false;
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

		static void MenuMusicaEncontrada()
		{

		}

		static void InicialiazarDadosCSV()
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

	}
}
