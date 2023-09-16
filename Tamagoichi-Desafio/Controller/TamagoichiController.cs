using Tamagoichi_Desafio.View;
using Tamagoichi_Desafio.Model;
using Tamagoichi_Desafio.Service;
using AutoMapper;

namespace Tamagoichi_Desafio.Controller
{
    public class TamagoichiController
    {
        private List<Mascote> MascotesAdotados { get; set; }
        private TamagoichiView mensagens { get; set; }
        private MascoteMapping Mapeador;

        public TamagoichiController()
        {
            this.MascotesAdotados = new List<Mascote>();
            this.mensagens = new TamagoichiView();
        }
        public void Jogar()
        {
            Mapeador = new MascoteMapping();
            int jogar = 1;
            string escolha;

            while (jogar == 1)
            {
                mensagens.MenuInicial();
                escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        MenuAdocao();
                        break;

                    case "2":
                        MenuInteracao();
                        break;

                    case "3":
                        jogar = 0;
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }
            }
        }

        private void MenuAdocao()
        {
            string especieEscolhida, escolha = "1";
            Pokemon pokemon = new Pokemon();
            Mascote mascote = new Mascote();

            especieEscolhida = mensagens.MenuAdocao();

            if (especieEscolhida == "BULBASAUR" || especieEscolhida == "IVYSAUR")
            {
                while (escolha != "3")
                {
                    escolha = mensagens.DesejaSaberMais(especieEscolhida);

                    switch (escolha)
                    {
                        case "1":
                            pokemon = PokemonService.BuscaCaracteristica(especieEscolhida);
                            mascote = Mapeador.mapper.Map<Pokemon, Mascote>(pokemon);
                            mensagens.DetalhesMascote(mascote);
                            break;

                        case "2":
                            pokemon = PokemonService.BuscaCaracteristica(especieEscolhida);
                            mascote = Mapeador.mapper.Map<Pokemon, Mascote>(pokemon);
                            this.MascotesAdotados.Add(mascote);
                            mensagens.SucessoAdocao();
                            escolha = "3";
                            break;

                        case "3":
                            escolha = "3";
                            break;

                        default:
                            Console.WriteLine("\nOpção inválida!");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nOpção inválida!");
            }
            
        }

        private void MenuInteracao()
        {
            if (MascotesAdotados.Count != 0)
            {
                string SubMenuInteracao = "0";
                int indiceMascote;

                indiceMascote = mensagens.VerMascotes(MascotesAdotados);
                if (indiceMascote > MascotesAdotados.Count - 1 || indiceMascote < 0)
                {
                    Console.WriteLine("\nOpção inválida!");
                    SubMenuInteracao = "4";
                }

                while (SubMenuInteracao != "4")
                {
                    SubMenuInteracao = mensagens.InteragirComMascotes(MascotesAdotados[indiceMascote]);

                    switch (SubMenuInteracao)
                    {
                        case "1":
                            mensagens.DetalhesMascoteAdotado(MascotesAdotados[indiceMascote]);
                            break;

                        case "2":
                            MascotesAdotados[indiceMascote].Alimentar();
                            mensagens.AlimentarMascote();

                            //if (!MascotesAdotados[indiceMascote].SaudeMascote())
                            //    mensagens.GameOver(MascotesAdotados[indiceMascote]);
                            break;

                        case "3":
                            MascotesAdotados[indiceMascote].Brincar();
                            mensagens.BrincarMascote();

                            if (!MascotesAdotados[indiceMascote].SaudeMascote())
                            {
                                mensagens.GameOver(MascotesAdotados[indiceMascote]);
                                MascotesAdotados.RemoveAt(indiceMascote);
                                SubMenuInteracao = "4";
                            }
                            break;

                        case "4":
                            break;

                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nVocê não possui mascotes adotados!");
            }
        }
    }
}
