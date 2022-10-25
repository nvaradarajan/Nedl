using System;
namespace minMaxAvg
{
    class program 
    {        
        static void Main()
        {
            Console.WriteLine ("Enter 10 Nos between 0 and 100");
            
            //#1 Get 10 Valid Numbers          
            int[] tenNumbers=new int[10];
            const int minNum=0, maxNum=100;
            int minimumNumber=maxNum+1;
            int maximumNumber=minNum-1;
            int counter, average=0, lessthanAvg=0,greaterthanAvg=0;
            tenNumbers=getIntArray(tenNumbers.Length,minNum,maxNum);

            //Calculate the min max average numbers
            int[] minMaxAvg=new int[3];
            minMaxAvg=getMinMaxAvgArray(tenNumbers,minNum,maxNum);
            minimumNumber=minMaxAvg[0];
            maximumNumber=minMaxAvg[1];
            average=minMaxAvg[2];
            
            //Count of Nos Less than average and greater than average
            for ( counter=0; counter < tenNumbers.Length; counter ++)
            {
                if (tenNumbers[counter] < average)
                {
                    lessthanAvg ++;
                }
                else
                {
                    greaterthanAvg ++;
                }
            }

            //#X Output
            foreach ( int i in tenNumbers)
            {            
             System.Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine ($"Count of Nos less than average : {lessthanAvg}");
            Console.WriteLine($"Count of Nos greater than or equal to average: {greaterthanAvg}");
        }//end of main

        //Get Inputs for an Integer array from user
        static int[] getIntArray(int arrayLength, int minNum, int maxNum)
        {
            int[] IntNumbers = new int[arrayLength];
            int counter=0;
            for ( counter=0; counter <= arrayLength-1; counter++)
            {
                Console.Write($"Enter Number {counter+1} : ");
                IntNumbers[counter]=Convert.ToInt32(Console.ReadLine());
                while (IntNumbers[counter] < minNum || IntNumbers[counter] > maxNum || IntNumbers[counter] % 1 != 0)
                {
                    Console.WriteLine("$Enter a Valid Number between {minNum} and {maxNum}");
                    Console.Write($"Enter Number {counter+1} : ");
                    IntNumbers[counter]=Convert.ToInt32(Console.ReadLine());
                }
            }
            
            return IntNumbers;

        } //end of getIntArray

        //Get Min, max and average for an array
        static int[] getMinMaxAvgArray(int[] arrayIn,int minNum,int maxNum)
        {
           int[] result = new int[3];
           result[0]=maxNum + 1;
           result[1]=minNum - 1;
           result[2]=0;
           int total=0;

           int counter=0;
            for ( counter=0; counter < arrayIn.Length; counter ++)
            {
                if (arrayIn[counter] < result[0])
                {
                    result[0] = arrayIn[counter];
                }
                else
                {
                    result[1] = arrayIn[counter];
                }
                total=total+arrayIn[counter];
            }
            result[2]=total/arrayIn.Length;
            return result;
        }
    } //end of program

}//end of namespace