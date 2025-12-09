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

		public void InserirInicio(Musica x)
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

		public void InserirFim(Musica x)
		{

			ultimo.Prox = new CelulaDupla(x);
			ultimo.Prox.Ant = ultimo;
			ultimo = ultimo.Prox;
		}

		public int BuscarPosicao(Musica musica)
		{
			int pos = 0;
			for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
			{
				if (i.Musica == musica)
					return pos;

				pos++;
			}
			return -1;
		}

		public bool BuscarMusica(string nome)
		{
			for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
			{
				if (i.Musica.Chave == nome)
				{
                    return true;
                }					
			}
			return false;
		}

		public void MoverCima(Musica musica)
		{
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Musica == musica)
				{
					if(i.Ant == primeiro)
						return;
					CelulaDupla a = i.Ant;
					CelulaDupla aa = i.Ant.Ant; 
					CelulaDupla p = i.Prox;

					aa.Prox = i;
					i.Ant = aa;
					i.Prox = a;
					a.Ant = i;
					a.Prox = p;
					if (p != null)
						p.Ant = a;					
				}
            }
        }

        public void MoverBaixo(Musica musica)
        {
            for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Musica == musica)
                {
                    if (i == ultimo)
                        return;
					
                    CelulaDupla p = i.Prox;
                    CelulaDupla a = i.Ant;
                    CelulaDupla pp = i.Prox.Prox;

					a.Prox = p;
                    p.Ant = a;
                    p.Prox = i;
					i.Ant = p;
                    i.Prox = pp;
					
					if(pp != null)
						pp.Ant = i;
					else
						ultimo = i;
                }
            }
        }


        public Musica RemoverInicio()
		{
			if (primeiro == ultimo)
			{
				throw new Exception("Lista cheia");
			}

			CelulaDupla temp = primeiro;
			primeiro = primeiro.Prox;
			Musica musica = primeiro.Musica;
			temp.Prox = primeiro.Ant = null;
			temp = null;
			return musica;
		}

		public Musica RemoverFim()
		{
			if (primeiro == ultimo)
			{
				throw new Exception("Lista cheia");
			}
			Musica musica = ultimo.Musica;
			ultimo = ultimo.Ant;
			ultimo.Prox.Ant = null;
			ultimo.Prox = null;
			return musica;

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

		public Musica Remover(int pos)
		{
			Musica musica;
			int tamanho = Tamanho();
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
                musica = RemoverInicio();
			}
			else if (pos == tamanho - 1)
			{
                musica = RemoverFim();
			}
			else
			{
				CelulaDupla i = primeiro;
				for (int j = 0; j < pos; j++, i = i.Prox) ;
                musica = i.Prox.Musica;
				i.Ant.Prox = i.Prox;
				i.Prox.Ant = i.Ant;
				i.Prox = null;
				i.Ant = null;
				i = null;
			}

			return musica;
		}

		public void CarregarFila(Fila fila){
			if (primeiro == ultimo)
			{
				throw new Exception("Playlist vazia!");
			}

			for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
			{
				fila.Enqueue(i.Musica);
			}
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
			Console.Write("[ ");
			for (CelulaDupla i = primeiro.Prox; i != null; i = i.Prox)
			{
				Console.Write($"{i.Musica.Titulo} - {i.Musica.Artista} | ");
			}
			Console.WriteLine(" ]");
		}

	}
}
