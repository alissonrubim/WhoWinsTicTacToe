using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWinsTicTacToe
{
    class Program
    {

        public class Velha
        {
            /// <summary>
            ///
            ///   O método analisa o registro de uma partida de jogo da velha e determina
            ///   quem venceu.
            ///
            /// </summary>
            ///
            /// <param name="partida">
            ///
            ///   A partida é registrada numa sequência de coordenadas separadas por
            ///   espaços:
            ///   
            ///     "x:2,2 o:2,1 x:3,3 o:1,1 x:3,1 o:1,3 x:3,2"
            ///       
            ///   Cada coordenada é formada da seguinte forma:
            ///   
            ///     - O símbolo do jogador seguido de dois pontos: 'x:' ou 'o:'
            ///     - A coordenada da linha e da coluna escolhida pelo jogador.
            ///       Os índices das linhas e das colunas variam entre 1 e 3.
            ///
            /// </param>
            /// 
            /// <returns>
            ///
            ///   O resultado é um inteiro identificando o empate ou o jogador vencedor da
            ///   seguinte forma:
            ///     -1  O jogador 'x' venceu a partida.
            ///      0  Nenhum jogador venceu a partida.
            ///      1  O jogador 'o' venceu a partida. 
            ///
            /// </returns>
            public int QuemVenceu(string partida)
            {
                tabuleiro = new Jogador[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, };
                foreach (string jogada in partida.Split(' '))
                {
                    Jogador jogadorAtual = (Jogador)Convert.ToInt32(jogada.Split(':')[0].ToLower() == "x" ? -1 : 1);

                    string movimentos = jogada.Split(':')[1];
                    int coluna = Convert.ToInt32(movimentos.Split(',')[0]) - 1;
                    int linha = Convert.ToInt32(movimentos.Split(',')[1]) - 1;

                    tabuleiro[linha, coluna] = jogadorAtual;

                    if (verificaGanhador(jogadorAtual) != Jogador.Nenhum)
                        return (int)jogadorAtual;
                }
                return 0;
            }

            private Jogador verificaGanhador(Jogador jogadorAtual)
            {
                int[,,] possibilidades = {
                    { {0,0 }, { 0,1 }, {0, 2} }, //linha 0
                    { {1,0 }, { 1,1 }, {1, 2} }, //linha 1 
                    { {2,0 }, { 2,1 }, {2, 2} }, //linha 2
                     
                    { {0,0 }, { 1,0 }, {2, 0} }, //coluna 0
                    { {0,1 }, { 1,1 }, {2, 1} }, //coluna 1
                    {  {0,2 }, { 1,2 }, {2, 2} },//coluna 2

                    {  {0,0 }, { 1,1 }, {2, 2} },//diagonal principal
                    {  {0,2 }, { 1,1 }, {0, 2} } //diagonal inversa
            };

                for (int i = 0; i < possibilidades.GetLength(0); i++)
                {
                    if (tabuleiro[possibilidades[i, 0, 0], possibilidades[i, 0, 1]] == jogadorAtual
                        && tabuleiro[possibilidades[i, 1, 0], possibilidades[i, 1, 1]] == jogadorAtual
                        && tabuleiro[possibilidades[i, 2, 0], possibilidades[i, 2, 1]] == jogadorAtual)
                        return jogadorAtual;
                }

                return Jogador.Nenhum;
            }

            private Jogador[,] tabuleiro;

            private enum Jogador
            {
                X = -1,
                Nenhum = 0,
                O = 1
            }
        }

        static void Main(string[] args)
        {
            var winmap = new string[,]
            {
                { "1,1", "1,2", "1,3" },
                { "2,1", "2,2", "2,3" },
                { "3,1", "3,2", "3,3" },
                { "1,1", "2,1", "3,1" },
                { "1,2", "2,2", "3,2" },
                { "1,3", "2,3", "3,3" },
                { "1,1", "2,2", "3,3" },
                { "3,1", "2,2", "1,3" },
            };

            var playmap = new string[,] { };

            foreach(string play in (Console.ReadLine()).Split(' '))
            {
                var player = play.Split(':')[0];
                var coord = play.Split(':')[1];

                
            }

            var nX = cmd.Where(u => u.Split(':')[0] == "x").Count();
            if (nX > cmd.Count() - nX)
                Console.Write("X ganhou");
            else if (nX < cmd.Count() - nX)
                Console.Write("O ganhou");
            else
                Console.Write("Empate");

            Console.ReadLine();
        }
    }
}