using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class Celula
	{
		private int elemento;
		private Celula prox;

		public Celula(int elemento)
		{
			this.elemento = elemento;
			this.prox = null;
		}

		public Celula()
		{
			this.elemento = 0;
			this.prox = null;
		}

		public Celula Prox
		{
			get { return prox; }
			set { prox = value; }
		}

		public int Elemento
		{
			get { return elemento; }
			set { elemento = value; }
		}
	}

}
