using System;

namespace Feet2Inch
{
    class program1 
    {
     static void Main(string[] args)
        {
            double inch;
            Console.Write ("Enter the number of Feet : ");
            double feet = Convert.ToDouble (Console.ReadLine());
            inch = feet*12;
            Console.WriteLine ("Converted Inches : {0}", inch );
            Console.WriteLine("{0} Feet  : {1} Inches", feet, inch);
            Console.ReadKey();
        }
    }
}