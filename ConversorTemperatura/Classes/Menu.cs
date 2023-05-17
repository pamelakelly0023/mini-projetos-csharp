using ConversorTemperatura.Interfaces;

namespace ConversorTemperatura.Classes
{
    public class Menu
    {
        public Menu()
        {
            ITemperatura temperatura = new Temperatura();
           

            int opcao = ObterOpcao();

            while(opcao < 4)
            {
                double valor = ObterValor();
                
                switch(opcao)
                {
                    case 1: temperatura.ConverterTemperaturaCelsius(valor); break;
                    case 2: temperatura.ConverterTemperaturaFahrenheit(valor); break;
                    case 3: temperatura.ConverterTemperaturaKelvin(valor);break;
                }

               opcao = ObterOpcao();
            }

            Console.WriteLine("Até a próxima!");
        }
        private int ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Qual tipo de temperatura você quer converter?");

            Console.WriteLine("1 - Celsius (C)");
            Console.WriteLine("2 - Fahrenheit (F)");
            Console.WriteLine("3 - Kelvin (K)");
            Console.WriteLine("4 - Sair");
            Console.WriteLine();

            // TO DO
            // Tratar dados de input

            int opcao = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return opcao;
        }

        private double ObterValor()
        {
            Console.WriteLine();
            Console.WriteLine("Qual valor você quer converter?");

            double valor = double.Parse(Console.ReadLine());
            return valor;

        }
    }
}