using Tamagoichi_Desafio.Controller;
using Tamagoichi_Desafio.Model;
using Tamagoichi_Desafio.Service;
using Tamagoichi_Desafio.View;

namespace TamagoichiDesafio
{
    class program
    {
        static void Main(string[] args)
        {
            TamagoichiController jogo = new TamagoichiController();
            jogo.Jogar();
        }
    }  
}

