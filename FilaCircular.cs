using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class Fila
	{
		public string[] array;
		public int primeiro;
		public int ultimo;

		public Fila(int tamanho)
		{
			array = new string[tamanho + 1];
			primeiro = ultimo = 0;
		}

		public Fila()
		{
			array = new string[6];
			primeiro = ultimo = 0;
		}

		public void Enqueue(string x)
		{
			if (((ultimo + 1) % array.Length) == primeiro) { throw new Exception("Erro"); }

			array[ultimo] = x;
			ultimo = (ultimo + 1) % array.Length;

		}

		public string Dequeue()
		{
			if (primeiro == ultimo) throw new Exception("Erro");

			string resp = array[primeiro];

			primeiro = (primeiro + 1) % array.Length;
			return resp;

		}

		public int Count()
		{
			if (primeiro == ultimo) throw new Exception("Erro");

			return ultimo;
		}

		public string Peek()
		{
			if (ultimo == 0) { throw new Exception("Fila vazia"); }
			return array[primeiro];
		}

		public void ForEach()
		{
			int i = primeiro;
			Console.Write("[");
			while (i != ultimo)
			{
				Console.Write(array[i] + " ");
				i = (i + 1) % array.Length;
			}
			Console.WriteLine("]");
		}


	}
}
