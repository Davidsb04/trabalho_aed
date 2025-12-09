using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class Player
	{
		private Fila fila;

		public Player(){
			fila = new Fila();
		}

		public void AdicionarMusica(Musica musica){
			fila.Enqueue(musica);
			Console.WriteLine($"\n->'{musica.Titulo} - {musica.Artista}' adicionada à fila.");
		}

		public void MostrarFila(){
			if (fila.IsEmpty())
			{
				Console.WriteLine("Fila de reprodução vazia!");
			}

			fila.ForEach();
		}

		public void ReproduzirProxima(){
			if (fila.IsEmpty())
			{
				Console.WriteLine("Nenhuma música na fila!");
			}

			Musica musica = fila.Dequeue();

			Console.WriteLine($"\n Reproduzindo {musica.Titulo} - {musica.Artista}");
		}
	}
}
