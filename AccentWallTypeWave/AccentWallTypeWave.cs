using System;
namespace AccentWallTypeWave
/* Calculate the count and dimension of the logs needed to build the Accent Wall of type Wave*/
{
    class AccentWallTypeWave
    {
        static void Main(string[] args)
        {
            /*Variables*/
            const string WallType="WAVE";
            double HeightOfTheWall;
            double LengthOfTheWall;
            double WaveLength;
            double WaveSpacing;
            double RowHeight;
            int logCount=0;
            int rowCount=0;
            int TotalLogCount=0;
            bool isError = false;
            bool isNegative = false;
            bool isRowHeightLonger = false;
            bool isWaveLengthLonger = false;
            

            /* Input*/
            Console.Write("Enter the Height of the wall in inches : ");
            HeightOfTheWall = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Enter the Width of the wall in inches : ");
            LengthOfTheWall = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the Width of the log used for Accent Wall in inches : ");
            WaveLength = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Enter the spacing between the logs for Accent Wall in inches : ");
            WaveSpacing = Convert.ToDouble(Console.ReadLine());
            
            /* Calculate log plus space*/
            RowHeight = WaveLength + WaveSpacing;

            /* Error Handling - Set Error Switch to True when Input is Negative*/
            if (HeightOfTheWall < 0 || LengthOfTheWall < 0 || WaveLength < 0 || WaveSpacing < 0 )
            {
                isError = true;
                isNegative = true;
            }

            /* Error Handling - Set Error Switch to True when Row Height is longer than Height of the Wall*/
            if (RowHeight >= HeightOfTheWall)
            {
                isError = true;
                isRowHeightLonger = true;
            }
            
            /* Error Handling - Set Error Switch to True when Wave Length is greater than length of the Wall*/
            if (WaveLength >= LengthOfTheWall)
            {
                isError = true;
                isWaveLengthLonger = true;
            }

            /*Calculate the Log Count for Accent Wall type-Stripe*/
            if (! isError)
              {
                logCount = (int) (LengthOfTheWall / WaveLength); /* no of waves */
                logCount = 2*logCount; /* no of logs needed for 1 row */
                rowCount = (int) (HeightOfTheWall/RowHeight); /* no of rows */
                TotalLogCount=logCount*rowCount; 
                /* Output */
                Console.WriteLine();
                Console.WriteLine("To build Accent Wall Type {4} for {1} X {2} Wall " +
                "you need - {0} Logs per row of height {3} inches ", logCount, HeightOfTheWall, LengthOfTheWall, WaveLength, WallType);
                Console.WriteLine("Total Number of rows is : {0}", rowCount);
                Console.WriteLine("Total Number of logs is : {0}", TotalLogCount);
              };
            
            /* Error Message*/
            if (isError)
            {
                if (isRowHeightLonger)
                    {
                    Console.WriteLine();
                    Console.WriteLine ("The Height of the wave is greater than or equal to the Height of the Wall and " +
                                       "cannot be used to build the Accent Wall type {0}",WallType);
                    } 
                else if (isWaveLengthLonger)
                    {
                    Console.WriteLine();
                    Console.WriteLine ("The Length of the wave is greater than or equal to the Length of the Wall and " +
                                       "cannot be used to build the Accent Wall type {0}", WallType);
                    }
                else if (isNegative)
                    {
                    Console.WriteLine();
                    Console.WriteLine ("Negative Values were entered "); 
                    }
            };

            
        }
    }
}