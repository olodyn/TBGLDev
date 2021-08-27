using System;
using Exercise01;
using static System.Console;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            string isNegative = "";

            try
            {

                WriteLine("Please Enter a number to convert to its words equivalent ");
                string number = Console.ReadLine();
                number = Convert.ToDouble(number).ToString();

                if (number.Contains("-"))
                {
                    isNegative = "Minus ";
                    number = number.Substring(1, number.Length - 1);
                }
                if (number == "0")
                {
                    Console.WriteLine("The number in word format is \nZero Only");
                }
                else
                {
                    Console.WriteLine("The number in word format is \n{0}", isNegative + ExtensionMethod.Towards(number));
                   
                }
                Console.ReadKey();


            }
            catch (Exception ex)
            {

                WriteLine(ex.Message);
            }
        }
    }
}
