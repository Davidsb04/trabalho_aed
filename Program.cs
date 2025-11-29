namespace PlayerMusical
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool executando = true;

			while (executando)
			{
				Console.Clear();
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
				Console.Clear();
				Console.WriteLine("===== GERENCIAR CATÁLOGO =====");
				Console.WriteLine("1 - Exibir Catálogo");
				Console.WriteLine("2 - Buscar Música");
				Console.WriteLine("3 - Carregar CSV Inicial");
				Console.WriteLine("4 - Inserir Música");
				Console.WriteLine("5 - Remover Música");
				Console.WriteLine("0 - Voltar");
				Console.Write("Opção: ");

				string opcao = Console.ReadLine();

				if (opcao == "0") loop = false;
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
	}
}
