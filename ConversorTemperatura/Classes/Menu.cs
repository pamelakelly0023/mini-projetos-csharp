namespace ConversorTemperatura.Classes
{
    public class MostrarMenu
    {
        public MostrarMenu()
        {
            
        }
        public string ObterOpcao()
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
    }
}