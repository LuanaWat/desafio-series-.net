using System;

namespace DIO.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
           
            while ( opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigada por utilizar os nossos serviços!");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar doramas");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum dorama cadastrado");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "EXCLUÍDO" : ""));
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir novo dorama");

            foreach (int i in Enum.GetValues(typeof(Origem)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Origem), i));
            }
            Console.WriteLine("Qual destes é o país de origem do dorama?");
            int entradaOrigem = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Conta aí qual é o gênero dele: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o nome do dorama? ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Em que ano ele saiu? ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("E agora o mais importante, me conte a história: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(Id: repositorio.ProximoId(),
                                        origem: (Origem)entradaOrigem,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Digite o ID do dorama: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Origem)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Origem), i));
            }
            Console.WriteLine("Qual destes é o país de origem do dorama?");
            int entradaOrigem = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Conta aí qual é o gênero dele: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o nome do dorama? ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Em que ano ele saiu? ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("E agora o mais importante, me conte a história: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(Id: indiceSerie,
                                        origem: (Origem)entradaOrigem,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }


        private static void ExcluirSeries()
        {
            Console.WriteLine("Digite o ID do dorama: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o ID do dorama: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Olá, está pensando em assistir o que?");
            Console.WriteLine("Me diga o que deseja!");
            Console.WriteLine("");
            Console.WriteLine("1- Lista os doramas");
            Console.WriteLine("2- Insere um novo dorama");
            Console.WriteLine("3- Atualiza um dorama");
            Console.WriteLine("4- Exclui um dorama");
            Console.WriteLine("5- Visualiza o dorama");
            Console.WriteLine("6- Limpa tela");
            Console.WriteLine("X- Sair (tchau tchau!)");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;        
        }
    }
}
