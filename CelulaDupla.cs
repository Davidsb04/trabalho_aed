using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class CelulaDupla
	{
		public int elemento;
		public CelulaDupla prox;
		public CelulaDupla ant;

		public CelulaDupla(int elemento)
		{
			this.elemento = elemento;
			prox = null;
			ant = null;
		}

		public CelulaDupla()
		{
			elemento = 0;
			prox = null;
			ant = null;
		}

		public int Elemento
		{
			get { return elemento; }
			set { elemento = value; }
		}

		public CelulaDupla Prox
		{
			get { return prox; }
			set { prox = value; }
		}

		public CelulaDupla Ant
		{
			get { return ant; }
			set { ant = value; }
		}
	}
}
