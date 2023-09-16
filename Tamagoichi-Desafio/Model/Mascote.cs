namespace Tamagoichi_Desafio.Model
{
    public class Mascote
    {
        public string name { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Abilities> abilities { get; set; }
        private int fome { get; set; }
        public int humor { get; set; }


        public Mascote()
        {
            Random ValorRandomico = new Random();
            this.DataNascimento= DateTime.Now;
            this.fome = ValorRandomico.Next(2, 10);
            this.humor = ValorRandomico.Next(2, 10);

        }

        public bool VerificarFome()
        {
            return this.fome < 5;
        }

        public bool VerificarHumor()
        {
            return this.humor < 5;
        }

        public void Alimentar()
        {
            this.fome++;
        }

        public void Brincar()
        {
            this.humor++;
            this.fome--;
        }

        public bool SaudeMascote()
        {
            return (this.fome > 0 && this.humor > 0);
        }
    }
}
