using ConversorTemperatura.Classes;
using ConversorTemperatura.Interfaces;

namespace ConversorTemperatura
{
    class Program
    {
        static void Main(string[] args)
        {
            ITemperatura temperatura = new Temperatura();
            MostrarMenu menu = new MostrarMenu();
            string opcao = menu.ObterOpcao();
            
        
            while(opcao.ToUpper() != "X")
            {
                double valor = ObterValor();
                
                switch(opcao)
                {
                    case "1": temperatura.ConverterTemperaturaCelsius(valor); break;
                    case "2": temperatura.ConverterTemperaturaFahrenheit(valor); break;
                    case "3": temperatura.ConverterTemperaturaKelvin(valor);break;
                }

                //opcao = ObterOpcao();
            }
            
           Console.WriteLine("Obrigado por utilizar nossos serviços.");
           Console.ReadLine();
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
