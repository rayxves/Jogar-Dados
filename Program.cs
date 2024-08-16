using System;

namespace JogarDados
{
    class Program
    {
        public void setDecoration(){
            Console.WriteLine("-##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--##--");
        }
        public void setInput(out string primeiroJogador, out string segundoJogador)
        {
            Console.WriteLine("\nInforme o nome do primeiro jogador: ");
            primeiroJogador = Console.ReadLine() ?? "jogador 1";

            Console.WriteLine("\nInforme o nome do segundo jogador: ");
            segundoJogador = Console.ReadLine() ?? "jogador 2";
        }

        public void startGame(string primeiroJogador, string segundoJogador)
        {
            setDecoration();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  Seja bem-vindo.\n  O jogo é dividido em n rodadas. O jogador que tirar o maior número no dado na maioria das jogadas vence a partida.\n  Em caso de empate (onde os dois tiram o mesmo número), nenhum jogador pontuará.");
            Console.ResetColor();
            setDecoration();

            int numeroDePartidas;
            while (true)
            {
                Console.WriteLine("\nDigite o número de rodadas: ");
                string input = Console.ReadLine() ?? "3";
                if (int.TryParse(input, out numeroDePartidas) && numeroDePartidas > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Número de rodadas inválido. Por favor, insira um número positivo.");
                }
            }

            setGame(numeroDePartidas, primeiroJogador, segundoJogador);
        }

        public void setGame(int numeroDePartidas, string primeiroJogador, string segundoJogador)
        {
            int partidas = 0;
            int pontosPrimeiroJogador = 0, pontosSegundoJogador = 0;
            Random random = new Random();

            while (partidas < numeroDePartidas)
            {
                int primeiroNumero = random.Next(1, 7);
                int segundoNumero = random.Next(1, 7);

                Console.WriteLine($"\n## Rodada {partidas + 1}:");

                Console.Write("\nNúmero do primeiro jogador: ");
                int numeroPrimeiroJogador = int.TryParse(Console.ReadLine(), out int resultPrimeiro) ? resultPrimeiro : 0;

                Console.Write("\nNúmero do segundo jogador: ");
                int numeroSegundoJogador = int.TryParse(Console.ReadLine(), out int resultSegundo) ? resultSegundo : 0;

                Console.ForegroundColor = ConsoleColor.Green;

                if (primeiroNumero.Equals(numeroPrimeiroJogador) && segundoNumero.Equals(numeroSegundoJogador))
                {
                    Console.WriteLine("\nEmpate na rodada.");
                }
                else if (primeiroNumero.Equals(numeroPrimeiroJogador))
                {
                    pontosPrimeiroJogador++;
                    Console.WriteLine($"\n{primeiroJogador} ganhou a rodada.");
                }
                else if (segundoNumero.Equals(numeroSegundoJogador))
                {
                    pontosSegundoJogador++;
                    Console.WriteLine($"\n{segundoJogador} ganhou a rodada.");
                }
                else
                {
                    Console.WriteLine("\nNenhum vencedor na rodada.");
                }

                partidas++;
                Console.ResetColor();
            }

            setWinner(pontosPrimeiroJogador, pontosSegundoJogador, primeiroJogador, segundoJogador);
        }

        public void setWinner(int pontosPrimeiroJogador, int pontosSegundoJogador, string primeiroJogador, string segundoJogador)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if (pontosPrimeiroJogador > pontosSegundoJogador)
            {
                Console.WriteLine($"\n{primeiroJogador} é o vencedor da partida.");
            }
            else if (pontosSegundoJogador > pontosPrimeiroJogador)
            {
                Console.WriteLine($"\n{segundoJogador} é o vencedor da partida.");
            }
            else
            {
                Console.WriteLine("\nEmpate!");
            }

            Console.ResetColor();
        }

        public static void Main()
        {
            Program jogo = new Program();

            string primeiroJogador, segundoJogador;
            jogo.setInput(out primeiroJogador, out segundoJogador);


            while (primeiroJogador.Equals(segundoJogador))
            {
                Console.WriteLine("Os nomes dos jogadores não podem ser iguais. Por favor, insira nomes diferentes.");
                jogo.setInput(out primeiroJogador, out segundoJogador);
            }

            bool tentarNovamente = true;

            while (tentarNovamente)
            {
                jogo.startGame(primeiroJogador, segundoJogador);
                Console.WriteLine("\nDeseja jogar novamente? (s/n)");

                string resposta = Console.ReadLine()?.ToLower() ?? "n";

                if (resposta == "s")
                {
                    tentarNovamente = true;
                }
                else if (resposta == "n")
                {
                    tentarNovamente = false;
                }
                else
                {
                    Console.WriteLine("Valor inválido.");
                    break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nObrigado por jogar!\n");
            Console.ResetColor();
            jogo.setDecoration();
           
        }
    }
}
