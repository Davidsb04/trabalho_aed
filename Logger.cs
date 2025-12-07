using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusical
{
	public static class Logger
	{
		private static string caminho = "log.txt";

		public static void Registrar(string mensagem){
			using (StreamWriter arq = new StreamWriter(caminho, true))
			{
				string linha = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] {mensagem}";
				arq.WriteLine(linha);
			}
		}
	}
}
