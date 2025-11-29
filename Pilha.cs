using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class Pilha
	{
		public Celula topo;

		public Pilha()
		{
			topo = null;
		}

		public void Inserir(int x)
		{
			Celula tmp = new Celula(x);
			tmp.Prox = topo;
			topo = tmp;
			tmp = null;
		}

		public int Remover()
		{
			if (topo == null)
			{
				throw new Exception("Erro");
			}
			int elemento = topo.Elemento;
			Celula tmp = topo;
			topo = topo.Prox;
			tmp.Prox = null;
			tmp = null;
			return elemento;
		}

		public void Mostrar()
		{
			Console.Write("[");
			for (Celula i = topo; i != null; i = i.Prox)
			{
				Console.Write(i.Elemento + "");
			}
			Console.WriteLine("]");
		}
	}
}
