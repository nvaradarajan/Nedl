using System;
namespace AccentWallTypeStripe
/* Calculate the count and dimension of the logs needed to build the Accent Wall of type Stripe*/
{
    class AccentWallTypeStripe
    {
        static void Main(string[] args)
        {
            /*Variables*/
            const string WallType = "STRIPE";
            double HeightOfTheWall;
            double LengthOfTheWall;
            double logWidth;
            double logSpacing;
            double logPlusSpace;
            int logCount=0;
            bool isError = false;
            bool isNegative = false;
            bool isLogWider = false;

            /* Input*/
            do
            {
            Console.Write("Enter the Height of the wall in inches : ");
            HeightOfTheWall = Convert.ToDouble(Console.ReadLine());
            } while (HeightOfTheWall > 0 );
            
            do
            {
            Console.Write("Enter the Width of the wall in inches : ");
            LengthOfTheWall = Convert.ToDouble(Console.ReadLine());
            } while (LengthOfTheWall > 0);
            
            do
            {
            Console.Write("Enter the Width of the log used for Accent Wall in inches : ");
            logWidth = Convert.ToDouble(Console.ReadLine());
            } while (logWidth > 0 );
            
            do
            {
            Console.Write("Enter the spacing between the logs for Accent Wall in inches : ");
            logSpacing = Convert.ToDouble(Console.ReadLine());
            
            } while (logSpacing >0); 

            /* Calculate log plus space*/
            logPlusSpace = logWidth + logSpacing;

            /* Error Handling - Set Error Switch to True when Input is Negative*/
            if (HeightOfTheWall < 0 || LengthOfTheWall < 0 || logWidth < 0 || logSpacing < 0 )
            {
                isError = true;
                isNegative = true;
            }

            /* Error Handling - Set Error Switch to True when log Width is greater than Width of the Wall*/
            if (logPlusSpace >= LengthOfTheWall)
            {
                isError = true;
                isLogWider = true;
            }
            
            /*Calculate the Log Count for Accent Wall type-Stripe*/
            if (! isError)
              {
                logCount = (int) (LengthOfTheWall / logPlusSpace);
                /* Output */
                Console.WriteLine();
                Console.Write("To build Accent Wall Type {4} for {1} X {2} Wall " +
                "you need - {0} Logs of height {1} inches and width {3} inches", logCount, HeightOfTheWall, LengthOfTheWall, logWidth, WallType);
              };
            
            /* Error Message*/
            if (isError)
            {
                if (isLogWider)
                    {
                    Console.WriteLine();
                    Console.WriteLine ("The width of the log is greater than or equal to the Width of the Wall and " +
                                       "cannot be used to build the Accent Wall type {0}",WallType);
                    } else if (isNegative)
                    {
                    Console.WriteLine();
                    Console.WriteLine ("Negative Values were entered "); 
                    }
            };

            
        }
    }
}