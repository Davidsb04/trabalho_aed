using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
    internal class Musica
    {
        private string titulo;
        private string artista;
        private string genero;
        private int duracao;
        private string chave;

        public Musica(string titulo, string artista, string genero, int duracao)
        {
            this.titulo = titulo;
            this.artista = artista;
            this.genero = genero;
            this.duracao = duracao;
            chave = titulo + artista;
        }
    }
}
