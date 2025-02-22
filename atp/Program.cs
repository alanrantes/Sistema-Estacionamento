using System;
class Program
{
    public static void Main()
    {
        string[] entrada = File.ReadAllLines("estacionamento_in.txt");

        string nomeEstacionamento = entrada[0];
        int vagasPrivativas = int.Parse(entrada[1]);
        int vagasPrioritarias = int.Parse(entrada[2]);
        int vagasComuns = int.Parse(entrada[3]);

        string historicoEntradas = "";
        string historicoSaidas = "";

        int opcao;
        do
        {
            opcao = Menu(nomeEstacionamento);

            if (opcao == 1)
            {
                (vagasPrivativas, vagasPrioritarias, vagasComuns, historicoEntradas) =
                    RegistrarEntrada(vagasPrivativas, vagasPrioritarias, vagasComuns, historicoEntradas);
            }
            else if (opcao == 2)
            {
                (vagasPrivativas, vagasPrioritarias, vagasComuns, historicoSaidas) =
                    RegistrarSaida(vagasPrivativas, vagasPrioritarias, vagasComuns, historicoSaidas);
            }
            else if (opcao == 3)
            {
                ConsultarVagas(vagasPrivativas, vagasPrioritarias, vagasComuns);
            }
            else if (opcao == 4)
            {
                ExibirResumo(historicoEntradas, historicoSaidas, vagasPrivativas, vagasPrioritarias, vagasComuns);
            }
            else if (opcao == 9)
            {
                Console.WriteLine("Encerrando programa...");
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }

        } while (opcao != 9);
    }

    static int Menu(string nomeEstacionamento)
    {
        Console.Clear();
        Console.WriteLine($"{nomeEstacionamento}");
        Console.WriteLine("1 - Registrar entrada");
        Console.WriteLine("2 - Registrar saída");
        Console.WriteLine("3 - Consultar vagas");
        Console.WriteLine("4 - Exibir resumo");
        Console.WriteLine("9 - Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static (int, int, int, string) RegistrarEntrada(int vagasPrivativas, int vagasPrioritarias, int vagasComuns, string historicoEntradas)
    {
        Console.Write("\nPlaca: ");
        string placa = Console.ReadLine();
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();
        Console.Write("Cor: ");
        string cor = Console.ReadLine();
        Console.Write("Proprietário: ");
        string proprietario = Console.ReadLine();

        Console.WriteLine("\nEscolha a vaga:");
        Console.WriteLine("1 - Privativa");
        Console.WriteLine("2 - Prioritária");
        Console.WriteLine("3 - Comum");
        int tipoVaga = int.Parse(Console.ReadLine());

        if (tipoVaga == 1 && vagasPrivativas > 0)
        {
            vagasPrivativas--;
            historicoEntradas += $"Placa: {placa}, Modelo: {modelo}, Cor: {cor}, Proprietário: {proprietario}, Vaga: Privativa\n";
            Console.WriteLine("Entrada registrada!");
        }
        else if (tipoVaga == 2 && vagasPrioritarias > 0)
        {
            vagasPrioritarias--;
            historicoEntradas += $"Placa: {placa}, Modelo: {modelo}, Cor: {cor}, Proprietário: {proprietario}, Vaga: Prioritária\n";
            Console.WriteLine("Entrada registrada!");
        }
        else if (tipoVaga == 3 && vagasComuns > 0)
        {
            vagasComuns--;
            historicoEntradas += $"Placa: {placa}, Modelo: {modelo}, Cor: {cor}, Proprietário: {proprietario}, Vaga: Comum\n";
            Console.WriteLine("Entrada registrada!");
        }
        else
        {
            Console.WriteLine("Vaga indisponível ou opção inválida.");
        }
        Pausar();
        return (vagasPrivativas, vagasPrioritarias, vagasComuns, historicoEntradas);
    }

    static (int, int, int, string) RegistrarSaida(int vagasPrivativas, int vagasPrioritarias, int vagasComuns, string historicoSaidas)
    {
        Console.Write("\nPlaca: ");
        string placa = Console.ReadLine();
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();
        Console.Write("Cor: ");
        string cor = Console.ReadLine();
        Console.Write("Proprietário: ");
        string proprietario = Console.ReadLine();

        Console.WriteLine("\nEscolha a vaga que ocupava:");
        Console.WriteLine("1 - Privativa");
        Console.WriteLine("2 - Prioritária");
        Console.WriteLine("3 - Comum");
        int tipoVaga = int.Parse(Console.ReadLine());

        if (tipoVaga == 1)
        {
            vagasPrivativas++;
            historicoSaidas += $"Placa: {placa}, Modelo: {modelo}, Cor: {cor}, Proprietário: {proprietario}, Vaga: Privativa\n";
            Console.WriteLine("Saída registrada!");
        }
        else if (tipoVaga == 2)
        {
            vagasPrioritarias++;
            historicoSaidas += $"Placa: {placa}, Modelo: {modelo}, Cor: {cor}, Proprietário: {proprietario}, Vaga: Prioritária\n";
            Console.WriteLine("Saída registrada!");
        }
        else if (tipoVaga == 3)
        {
            vagasComuns++;
            historicoSaidas += $"Placa: {placa}, Modelo: {modelo}, Cor: {cor}, Proprietário: {proprietario}, Vaga: Comum\n";
            Console.WriteLine("Saída registrada!");
        }
        else
        {
            Console.WriteLine("Operação inválida para a vaga selecionada.");
        }
        Pausar();
        return (vagasPrivativas, vagasPrioritarias, vagasComuns, historicoSaidas);
    }

    static void ConsultarVagas(int vagasPrivativas, int vagasPrioritarias, int vagasComuns)
    {
        string resultado = "\nVagas disponíveis:\n";
        resultado = resultado + "Privativas: " + vagasPrivativas + "\n";
        resultado = resultado + "Prioritárias: " + vagasPrioritarias + "\n";
        resultado = resultado + "Comuns: " + vagasComuns + "\n";
        resultado = resultado + "*****\n";

        Console.WriteLine(resultado);
        File.WriteAllText("estacionamento_out.txt", resultado);
        Pausar();
    }

    static void ExibirResumo(string historicoEntradas, string historicoSaidas, int vagasPrivativas, int vagasPrioritarias, int vagasComuns)
    {
        string resultado = "Resumo do estacionamento:\n";
        resultado = resultado + "Vagas Privativas: " + vagasPrivativas + "\n";
        resultado = resultado + "Vagas Prioritárias: " + vagasPrioritarias + "\n";
        resultado = resultado + "Vagas Comuns: " + vagasComuns + "\n";
        resultado = resultado + "\nCarros que entraram:\n" + historicoEntradas;
        resultado = resultado + "\nCarros que saíram:\n" + historicoSaidas;
        resultado = resultado + "*****\n";

        Console.Clear();
        Console.WriteLine(resultado);
        File.WriteAllText("estacionamento_out.txt", resultado);
        Pausar();
    }


    static void Pausar()
    {
        Console.WriteLine("\nPressione [Enter] para continuar...");
        Console.ReadKey();
    }
}