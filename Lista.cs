using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class Lista
	{
		private Celula primeiro, ultimo;

		public Lista()
		{
			primeiro = new Celula();
			ultimo = primeiro;
		}

		public void InserirInicio(Musica x)
		{
			Celula tmp = new Celula(x);
			tmp.Prox = primeiro.Prox;
			primeiro.Prox = tmp;
			if (primeiro == ultimo)
			{
				ultimo = tmp;
			}

			tmp = null;
		}

		public Musica RemoverFim()
		{
			if (primeiro == ultimo)
			{
				throw new Exception("Lista vazia");
			}

			Celula i;
			for (i = primeiro; i.Prox != ultimo; i = i.Prox) ;
			Musica elemento = ultimo.Elemento;
			ultimo = i;
			i.Prox = null;
			i = null;
			return elemento;
		}

		public void InserirFim(Musica x)
		{
			ultimo.Prox = new Celula(x);
			ultimo = ultimo.Prox;
		}

		public void Inserir(Musica x, int pos)
		{
			int tamanho = Tamanho();
			if (pos < 0 || pos > tamanho)
			{
				throw new Exception("Erro");
			}
			else if (pos == tamanho)
			{
				InserirFim(x);
			}
			else if (pos == 0)
			{
				InserirInicio(x);
			}
			else
			{
				Celula i = primeiro;
				for (int j = 0; j < pos; j++, i = i.Prox) ;
				Celula temp = new Celula(x);
				temp.Prox = i.Prox;
				i.Prox = temp;
				temp.Prox = null;
				temp = null;
				i = null;
			}
		}

		public Musica Remover(int pos)
		{
			Musica elemento = null;
			int tamanho = Tamanho();
			if (primeiro == ultimo || pos < 0 || pos > tamanho)
			{
				throw new Exception("Erro");
			}
			else if (pos == tamanho)
			{
				elemento = RemoverFim();
			}
			else if (pos == 0)
			{
				elemento = RemoverInicio();
			}
			else
			{
				Celula i = primeiro;
				for (int j = 0; j < pos; j++, i = i.Prox) ;
				Celula temp = i.Prox;
				elemento = temp.Elemento;
				i.Prox = temp.Prox;
				temp.Prox = null;
				i = temp = null;
			}
			return elemento;
		}

		public int Tamanho()
		{
			int count = 0;
			for (Celula i = primeiro.Prox; i != null; i = i.Prox)
			{
				count++;
			}

			return count;
		}

		public Musica RemoverInicio()
		{
			if (primeiro == ultimo)
			{
				throw new Exception("Lista vazia");
			}

			Celula temp = primeiro;
			primeiro = primeiro.Prox;
			Musica elemento = primeiro.Elemento;
			temp.Prox = null;
			temp = null;
			return elemento;

		}

		public void Mostrar()
		{
			Console.Write("[");
			for (Celula i = primeiro.Prox; i != null; i = i.Prox)
			{
				Console.WriteLine(i.Elemento.Titulo + "-" + i.Elemento.Artista);
			}
			Console.WriteLine("]");
		}

		public void MostrarUltimos10()
		{
			int tamanho = Tamanho();

			if (tamanho == 0)
			{
				Console.WriteLine("Lista vazia");
				return;
			}

			int pular = Math.Max(0, tamanho - 10);

			Celula i = primeiro.Prox;

			for (int j = 0; j < pular; j++)
			{
				i = i.Prox;
			}

			Console.WriteLine("Últimas 10 músicas:");

			while (i != null)
			{
				Console.WriteLine(i.Elemento.Titulo + " - " + i.Elemento.Artista);
				i = i.Prox;
			}
		}

		public bool Vazio(){
			if (primeiro == ultimo)
			{
				return true;
			}

			return false;
		}


	}
}
