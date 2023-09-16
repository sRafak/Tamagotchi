using Tamagoichi_Desafio.Model;

namespace Tamagoichi_Desafio.View
{
    public class TamagoichiView
    {
        private string nomeJogador { get; set; }
        public TamagoichiView()
        {
            BoasVindas();
        }

        private void BoasVindas()
        {
            Console.WriteLine(@" 
     #######                                                                    
        #       ##    #    #    ##     ####    ####   #####   ####   #    #  # 
        #      #  #   ##  ##   #  #   #    #  #    #    #    #    #  #    #  # 
        #     #    #  # ## #  #    #  #       #    #    #    #       ######  # 
        #     ######  #    #  ######  #  ###  #    #    #    #       #    #  # 
        #     #    #  #    #  #    #  #    #  #    #    #    #    #  #    #  # 
        #     #    #  #    #  #    #   ####    ####     #     ####   #    #  #");

            Console.WriteLine("\n\nQual é seu nome?");
            nomeJogador = Console.ReadLine().ToUpper();
        }

        public void MenuInicial()
        {
            //Console.Clear();
            Console.WriteLine("\n\n----------------- MENU -----------------");
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - Adotar um mascote virtual");
            Console.WriteLine("2 - Ver seus mascotes");
            Console.WriteLine("3 - Sair");
        }

        public string MenuAdocao()
        {
            //Console.Clear();
            Console.WriteLine("\n----------------- ADOTAR UM MASCOTE -----------------");
            Console.WriteLine($"{nomeJogador}, Escolha uma espécie:");
            Console.WriteLine("Bulbasaur");
            Console.WriteLine("Ivysaur");

            return Console.ReadLine().ToUpper();
        }

        public string DesejaSaberMais(string especieEscolhida)
        {
            //Console.Clear();
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine($"{nomeJogador}, Você deseja: ");
            Console.WriteLine($"1 - Saber mais sobre {especieEscolhida}");
            Console.WriteLine($"2 - Adotar {especieEscolhida}");
            Console.WriteLine("3 - Voltar");

            return Console.ReadLine().ToUpper();
        }

        public void DetalhesMascote(Mascote mascote)
        {
            Console.WriteLine("\n----------------- CARACTERÍSITCAS -----------------");
            Console.WriteLine($"Nome: {mascote.name.ToUpper()}");
            Console.WriteLine($"Altura: {mascote.height}");
            Console.WriteLine($"Massa: {mascote.weight}");
            Console.WriteLine("Habilidades: ");
            foreach (var item in mascote.abilities)
            {
                Console.WriteLine(item.ability.name.ToUpper());
            }
        }

        public void DetalhesMascoteAdotado(Mascote mascote)
        {
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("name Pokemon: " + mascote.name.ToUpper());
            Console.WriteLine("Altura: " + mascote.height);
            Console.WriteLine("Peso: " + mascote.weight);

            System.TimeSpan idade = DateTime.Now.Subtract(mascote.DataNascimento);

            Console.WriteLine("Idade: " + idade.Minutes + " Anos em Pokemon Virtual");

            if (mascote.VerificarFome())
                Console.WriteLine($"{mascote.name.ToUpper()} Está com fome!");
            else
                Console.WriteLine($"{mascote.name.ToUpper()} Está alimentado!");

            if (mascote.humor > 5)
                Console.WriteLine($"{mascote.name.ToUpper()} Está feliz!");
            else
                Console.WriteLine($"{mascote.name.ToUpper()} Está triste!");

            Console.WriteLine("Habilidades: ");
            foreach (Abilities item in mascote.abilities)
            {
                Console.Write(item.ability.name.ToUpper());
            }
        }

        public void SucessoAdocao()
        {
            Console.WriteLine($"{nomeJogador}, POKEMON ADOTADO COM SUCESSO, O OVO ESTÁ CHOCANDO: ");

            Console.WriteLine(@"
              ███╗
             ██████╗
            ████████╗
            ████████║
            ████████║
            ╚█████╔╝
             ╚════╝");
        }

        public int VerMascotes(List<Mascote> MascotesAdotados)
        {
            Console.WriteLine("\n----------------- MASCOTES -----------------");
            for (int indicePokemon = 0; indicePokemon < MascotesAdotados.Count; indicePokemon++)
            {
                Console.WriteLine($"{indicePokemon} - {MascotesAdotados[indicePokemon].name.ToUpper()}");
            }
            Console.WriteLine($"{nomeJogador}, Qual pokemon deseja interagir?");

            return Convert.ToInt32(Console.ReadLine());
        }

        public string InteragirComMascotes(Mascote Pokemon)
        {
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine($"{nomeJogador} VOCÊ DESEJA:");
            Console.WriteLine($"1 - SABER COMO {Pokemon.name.ToUpper()} ESTÁ");
            Console.WriteLine($"2 - ALIMENTAR O {Pokemon.name.ToUpper()}");
            Console.WriteLine($"3 - BRINCAR COM {Pokemon.name.ToUpper()} ");
            Console.WriteLine($"4 - VOLTAR");

            return Console.ReadLine().ToUpper();
        }

        public void AlimentarMascote()
        {
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine($" (=^w^=)");
            Console.WriteLine($"Pokemon Alimentado");
        }

        public void BrincarMascote()
        {
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine($"(=^w^=)");
            Console.WriteLine($"Mascote mais feliz");
        }

        public void GameOver(Mascote Pokemon)
        {
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("O Mascote morreu de " + (Pokemon.humor > 0 ? "fome" : "tristeza"));

            Console.WriteLine(@"
              #####      #     #     #  #######      #######  #     #  #######  ######  
             #     #    # #    ##   ##  #            #     #  #     #  #        #     # 
             #         #   #   # # # #  #            #     #  #     #  #        #     # 
             #  ####  #     #  #  #  #  #####        #     #  #     #  #####    ######  
             #     #  #######  #     #  #            #     #   #   #   #        #   #   
             #     #  #     #  #     #  #            #     #    # #    #        #    #  
              #####   #     #  #     #  #######      #######     #     #######  #     # ");
        }
    }
}
