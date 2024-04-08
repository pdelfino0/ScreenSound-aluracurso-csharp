Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>
{
    { "Iron Maiden", new List<int> { 5, 7, 8 } },
    { "Metallica", new List<int> { 4, 1, 2 } },
    { "Megadeth", new List<int> { 3, 5, 8 } }
};

void exibirLogo()
{
    //Exibir uma Ascii Art com o Verbatim Literal
    Console.WriteLine(@"
███████╗ ██████╗██████╗ ███████╗███████╗███╗   ██╗    ███████╗ ██████╗ ██╗   ██╗███╗   ██╗██████╗ 
██╔════╝██╔════╝██╔══██╗██╔════╝██╔════╝████╗  ██║    ██╔════╝██╔═══██╗██║   ██║████╗  ██║██╔══██╗
███████╗██║     ██████╔╝█████╗  █████╗  ██╔██╗ ██║    ███████╗██║   ██║██║   ██║██╔██╗ ██║██║  ██║
╚════██║██║     ██╔══██╗██╔══╝  ██╔══╝  ██║╚██╗██║    ╚════██║██║   ██║██║   ██║██║╚██╗██║██║  ██║
███████║╚██████╗██║  ██║███████╗███████╗██║ ╚████║    ███████║╚██████╔╝╚██████╔╝██║ ╚████║██████╔╝
╚══════╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚══════╝╚═╝  ╚═══╝    ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝╚═════╝ 
                                                                                                 ");
}

void ExibirTituloDaOpcao(string titulo)
{
    Console.Clear();
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void ExibirMensagemBoasVindas()
{
    Console.WriteLine("Bem-vindo ao ScreenSound");
    exibirLogo();
}

void RegistrarBanda()
{
    ExibirTituloDaOpcao("Registro de uma banda!");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"A Banda {nomeBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    Menu();
}

void Menu()
{
    ExibirMensagemBoasVindas();
    ExibirTituloDaOpcao("Menu");
    Console.WriteLine("1 - Para adicionar uma nova banda");
    Console.WriteLine("2 - Para listar as bandas");
    Console.WriteLine("3 - Para avaliar uma banda");
    Console.WriteLine("4 - Para exibir a média de avaliação de uma banda");
    Console.WriteLine("-1 - Para sair");

    Console.Write("Digite a opção desejada: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            ListarBandas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMediaDeUmaBanda();
            break;
        case -1:
            Console.WriteLine("Tchau!");
            break;
        default:
            Console.WriteLine("Opção digitada é inválida");
            break;
    }
}

ExibirMensagemBoasVindas();
Menu();

void ListarBandas()
{
    ExibirTituloDaOpcao("Listagem de bandas!");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine(banda);
        Console.WriteLine($"Avaliações da banda: {banda}");
        foreach (int avaliacao in bandasRegistradas[banda])
        {
            Console.WriteLine($"Nota:{avaliacao}");
        }
    }

    Thread.Sleep(2000);
    Menu();
}

void AvaliarUmaBanda()
{
    ExibirTituloDaOpcao("Avaliar uma banda!");
    string bandaASerAvaliada = string.Empty;
    while (true)
    {
        Console.Write("Digite a banda que você deseja avaliar:");
        bandaASerAvaliada = Console.ReadLine()!;
        if (!bandasRegistradas.ContainsKey(bandaASerAvaliada))
        {
            Console.Write("A opção digitada não existe ou houve um erro de digitação, tente novamente:");
        }
        else
        {
            break;
        }
    }

    Console.WriteLine($"Qual a nota que a banda {bandaASerAvaliada} merece?");
    int nota = int.Parse(Console.ReadLine()!);
    bandasRegistradas[bandaASerAvaliada].Add(nota);
    Console.WriteLine($"A nota {nota} foi atribuida a banda {bandaASerAvaliada} com sucesso!");
    Thread.Sleep(2000);
    Menu();
}

void ExibirMediaDeUmaBanda()
{
    ExibirTituloDaOpcao("Exibir a média de uma banda");
    Console.WriteLine("Essas são as bandas registradas:");
    foreach (var banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"{banda}");
    }
    Console.Write("Dentre essas, qual banda você deseja exibir a média?");

    string bandaSelecionada = Console.ReadLine()!;
    if (!bandasRegistradas.ContainsKey(bandaSelecionada)) {
        Console.WriteLine("Banda não encontrada! Talvez houve um erro de digitação, tente novamente, por favor! ");
    }
    else
    {
        Console.WriteLine(bandasRegistradas[bandaSelecionada].Average());
    }
}