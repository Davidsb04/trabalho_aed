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

        public string Nome
        {
            get {  return nome; }
            set { this.nome = value; }
        }

        public void InserirMusica(Musica musica)
        {
            playlist.InserirFim(musica);
        }

        public void ExibirMusicas()
        {
            playlist.Mostrar();
        }

        public void RemoverMusica(Musica musica)
        {
            int pos = playlist.BuscarPosicao(musica);
            playlist.Remover(pos);
        }


        public bool BuscarMusica(string nomeMusica)
        {
            if(playlist.BuscarMusica(nomeMusica))
                return true;
            return false;
        }

        public void MoverMusicaCima(Musica musica)
        {
            playlist.MoverCima(musica);
        }

        public void MoverMusicaBaixo(Musica musica)
        {
            playlist.MoverBaixo(musica);
        }

		public void CarregarMusicaFila(Fila fila)
		{
			playlist.CarregarFila(fila);
		}
	}
}
