using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
    internal class Playlist
    {
        private string nome;
        private ListaDupla playlist;

        public Playlist(string nome)
        {
            this.nome = nome;
            playlist = new ListaDupla();
        }

    }
}
