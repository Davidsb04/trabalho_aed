using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class Fila
	{
		private Musica[] array;
		private int primeiro;
		private int ultimo;

		public Fila(int tamanho)
		{
			array = new Musica[tamanho + 1];
			primeiro = ultimo = 0;
		}

		public Fila()
		{
			array = new Musica[11];
			primeiro = ultimo = 0;
		}

		public void Enqueue(Musica x)
		{
			if (((ultimo + 1) % array.Length) == primeiro) { throw new Exception("Erro"); }

			array[ultimo] = x;
			ultimo = (ultimo + 1) % array.Length;

		}

		public Musica Dequeue()
		{
			if (primeiro == ultimo) throw new Exception("Erro");

			Musica resp = array[primeiro];

			primeiro = (primeiro + 1) % array.Length;
			return resp;

		}

		public int Count()
		{
			if (primeiro == ultimo) throw new Exception("Erro");

			return ultimo;
		}

		public Musica Peek()
		{
			if (ultimo == 0) { throw new Exception("Fila vazia"); }
			return array[primeiro];
		}

		public void ForEach()
		{
			int i = primeiro;
			Console.WriteLine("=== Fila de Reprodução ===");
			while (i != ultimo)
			{
				Console.WriteLine($"{array[i].Titulo} - {array[i].Artista}");
				i = (i + 1) % array.Length;
			}
			Console.WriteLine("==========================");
		}

		public bool IsEmpty(){
			 if (primeiro == ultimo) {
				return true;
			} else {
				return false;
			} 
		}


	}
}
