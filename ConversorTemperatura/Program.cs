using ConversorTemperatura.Classes;
using ConversorTemperatura.Interfaces;

namespace ConversorTemperatura
{
    class Program
    {
        static void Main(string[] args)
        {
            ITemperatura temperatura = new Temperatura();
           
            string opcao = ObterOpcao();
            
        
            while(opcao.ToUpper() != "X")
            {
                double valor = ObterValor();
                
                switch(opcao)
                {
                    case "1": temperatura.converterTemperaturaCelsius(valor); break;
                    case "2": temperatura.converterTemperaturaFahrenheit(valor); break;
                    case "3": temperatura.converterTemperaturaKelvin(valor);break;
                }

                opcao = ObterOpcao();
            }
            
           Console.WriteLine("Obrigado por utilizar nossos serviços.");
           Console.ReadLine();
        }


        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Qual tipo de temperatura você quer converter?");

            Console.WriteLine("1 - Celsius (C)");
            Console.WriteLine("2 - Fahrenheit (F)");
            Console.WriteLine("3 - Kelvin (K)");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = (Console.ReadLine()).ToUpper();
            Console.WriteLine();
            return opcao;
        }

        private static double ObterValor()
        {
            Console.WriteLine();
            Console.WriteLine("Qual valor você quer converter?");

            double valor = double.Parse(Console.ReadLine());
            return valor;

        }
    }
}
