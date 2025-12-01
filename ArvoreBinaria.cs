using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
    internal class ArvoreBinaria
    {
        private No raiz;

        public ArvoreBinaria()
        {
            raiz = null;
        }

        public void Inserir(Musica musica)
        {
            raiz = Inserir(raiz, musica);
        }

        private No Inserir(No atual, Musica musica)
        {
            if (atual == null)
            {
                atual = new No(musica.Genero);
                atual.Musicas.Add(musica);
                return atual;
            }

            int comparacao = string.Compare(musica.Genero, atual.Genero, StringComparison.OrdinalIgnoreCase);

            if (comparacao == 0)
            {
                atual.Musicas.Add(musica);
            }
            else if (comparacao < 0)
            {
                atual.Esq = Inserir(atual.Esq, musica);
            }
            else
            {
                atual.Dir = Inserir(atual.Dir, musica);
            }
            return atual;
        }

        public List<Musica> Pesquisar(string genero)
        {
            return Pesquisar(raiz, genero);
        }

        private List<Musica> Pesquisar(No atual, string genero)
        {
            if (atual == null)
                return null;

            int comparacao = string.Compare(genero, atual.Genero, StringComparison.OrdinalIgnoreCase);

            if (comparacao == 0)
                return atual.Musicas;

            if (comparacao < 0)
                return Pesquisar(atual.Esq, genero);
            else
                return Pesquisar(atual.Dir, genero);
        }
    }
}
