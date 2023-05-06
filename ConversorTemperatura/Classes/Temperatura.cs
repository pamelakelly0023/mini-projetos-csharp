using ConversorTemperatura.Interfaces;

namespace ConversorTemperatura.Classes
{
    public class Temperatura : ITemperatura
    { 
        // TODO
        // 
        // formatar resultao
        public Temperatura()
        {
            
        }

        public void ConverterTemperaturaCelsius(double valor)
        {
        
            double celsiusParaFahrenheit = valor * 1.8 + 32;
            double celsiusParaKelvin = valor + 273;
            
 
            string resultado = ($"Conversão de {valor}ºC para Fahrenheit é: " + celsiusParaFahrenheit + "ºF\r\n" +
                                $"Conversão de {valor}ºC para Kelvin é: " + celsiusParaKelvin + "K" );

            Console.WriteLine(resultado);
        }

        public void ConverterTemperaturaFahrenheit(double valor)
        {

            double fahrenheitParaCelsius = (valor - 32)/1.8000;
            double fahrenheitParaKelvin = (valor + 459.67) * 5/9; 

            string resultado = ($"Conversão de {valor}ºF para Celsius é: " + fahrenheitParaCelsius + "ºC\r\n" +
                                $"Conversão de {valor}ºF para Kelvin é: " + fahrenheitParaKelvin + "K" );

            Console.WriteLine(resultado);
        }

        public void ConverterTemperaturaKelvin(double valor)
        {
    
            double kelvinParaCelsius = valor - 273.15;
            double kelvinParaFahrenheit = (valor - 273.15) * (9/5 + 32);

             string resultado = ($"Conversão de {valor}K para Celsius é: " + kelvinParaCelsius + "ºC\r\n" +
                                $"Conversão de {valor}K para Fahrenheit é: " + kelvinParaFahrenheit + "ºF" );

            Console.WriteLine(resultado);
            
        }
    }
}