using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	class CelulaDupla
	{
		public Musica musica;
		public CelulaDupla prox;
		public CelulaDupla ant;

		public CelulaDupla(Musica musica)
		{
			this.musica = musica;
			prox = null;
			ant = null;
		}

		public CelulaDupla()
		{
			musica = null;
			prox = null;
			ant = null;
		}

		public Musica Musica
		{
			get { return musica; }
			set { musica = value; }
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
