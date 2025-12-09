using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class Celula
	{
		private Musica elemento;
		private Celula prox;

		public Celula(Musica elemento)
		{
			this.elemento = elemento;
			this.prox = null;
		}

		public Celula()
		{
			this.elemento = null;
			this.prox = null;
		}

		public Celula Prox
		{
			get { return prox; }
			set { prox = value; }
		}

		public Musica Elemento
		{
			get { return elemento; }
			set { elemento = value; }
		}
	}

}
