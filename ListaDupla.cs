using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class ListaDupla
	{
		public CelulaDupla primeiro, ultimo;

		public ListaDupla()
		{
			primeiro = new CelulaDupla();
			ultimo = primeiro;
		}

		public void InserirInicio(int x)
		{
			CelulaDupla temp = new CelulaDupla(x);
			temp.Ant = primeiro;
			temp.Prox = primeiro.Prox;
			primeiro.Prox = temp;

			if (primeiro == ultimo)
			{
				ultimo = temp;
			}
			else
			{
				temp.Prox.Ant = temp;
			}
			temp = null;
		}

		public void InserirFim(int x)
		{

			ultimo.Prox = new CelulaDupla(x);
			ultimo.Prox.Ant = ultimo;
			ultimo = ultimo.Prox;
		}

		public int RemoverInicio()
		{
			if (primeiro == ultimo)
			{
				throw new Exception("Lista cheia");
			}

			CelulaDupla temp = primeiro;
			primeiro = primeiro.Prox;
			int elemento = primeiro.Elemento;
			temp.Prox = primeiro.Ant = null;
			temp = null;
			return elemento;
		}

		public int RemoverFim()
		{
			if (primeiro == ultimo)
			{
				throw new Exception("Lista cheia");
			}
			int elemento = ultimo.Elemento;
			ultimo = ultimo.Ant;
			ultimo.Prox.Ant = null;
			ultimo.Prox = null;
			return elemento;

		}

		public void Inserir(int x, int pos)
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
				CelulaDupla i = primeiro;
				for (int j = 0; j < pos; j++, i = i.Prox) ;
				CelulaDupla temp = new CelulaDupla(x);
				temp.Ant = i;
				temp.Prox = i.Prox;
				temp.Ant.Prox = temp;
				temp.Prox.Ant = temp;
				temp = i = null;
			}
		}

		public int Remover(int pos)
		{
			int elemento, tamanho = Tamanho();
			if (primeiro == ultimo)
			{
				throw new Exception("Erro!");
			}
			else if (pos < 0 || pos >= tamanho)
			{
				throw new Exception("Erro!");
			}
			else if (pos == 0)
			{
				elemento = RemoverInicio();
			}
			else if (pos == tamanho - 1)
			{
				elemento = RemoverFim();
			}
			else
			{
				CelulaDupla i = primeiro;
				for (int j = 0; j < pos; j++, i = i.Prox) ;
				elemento = i.Prox.Elemento;
				i.Ant.Prox = i.Prox;
				i.Prox.Ant = i.Ant;
				i.Prox = null;
				i.Ant = null;
				i = null;
			}

			return elemento;
		}

		public int Tamanho()
		{
			int count = 0;
			for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
			{
				count++;
			}

			return count;
		}


		public void Mostrar()
		{
			Console.Write("[");
			for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
			{
				Console.Write(i.Elemento + " ");
			}
			Console.WriteLine("]");
		}

	}
}
