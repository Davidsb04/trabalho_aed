using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
    internal class No
    {
        private string genero;
        private List<Musica> musicas;
        private No esq;
        private No dir;
        
        public No(string genero)
        {
            this.genero = genero;
            musicas = new List<Musica>();
            esq = null;
            dir = null;
        }

        public No(string genero, No esq, No dir)
        {
            this.genero = genero;
            musicas = new List<Musica>();
            this.dir = dir;
            this.esq = esq;
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }
        public No Esq
        {
            get { return esq; }
            set { esq = value; }
        }
        public No Dir
        {
            get { return dir; }
            set { dir = value; }
        }

        public List<Musica> Musicas
        {
            get { return musicas; }
        }
    }
}
