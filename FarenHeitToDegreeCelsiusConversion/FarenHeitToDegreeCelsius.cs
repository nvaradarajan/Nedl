using System;
namespace FarenHeitToDegreeCelsius
{
 class Program
    {
        static void Main()
        {
            double farenHeit;
            double degreeCelsius;

            Console.Write("Enter the Faren Heit : ");
            farenHeit = Convert.ToDouble(Console.ReadLine());
            
            degreeCelsius =  (farenHeit - 32) * 5/9;
            
            Console.WriteLine ("The {0} farenHeit converted to degree celsius {1}", farenHeit, degreeCelsius);

        }

    }
}
