using System;
namespace twoDimensionalarray
{
    class program
    {
        static void Main()
        {
            //Welcome Message
            Console.WriteLine();
            Console.WriteLine("Welcome to Two Dimensional Array");
            Console.WriteLine();

            //Variables for Two Dimensionla Array
            int noOfStudent = 0, noOfSubject = 0;
            const int minStudent=1, maxStudent=10, minSubject=1, maxSubject=5;
            noOfStudent = getValidInt("Enter the no of Students",minStudent,maxStudent);
            noOfSubject = getValidInt("Enter the no of Subjects",minSubject,maxSubject);
            

            //Get Data from User
            const int minScore=0, maxScore=100;
            String [,] studentReport = new String[noOfStudent,noOfSubject];
            studentReport=get2DInput(noOfStudent,noOfSubject,"student Name","Score #",minScore, maxScore);


            //Display Output
            String [,] result = new String[noOfStudent,4];            
            result=getMinMaxAvg(studentReport,noOfStudent,noOfSubject);
            for(int Count1=0; Count1 < noOfStudent; Count1++) 
            {            
                Console.WriteLine();    
                Console.WriteLine($"{result[Count1,0]} has a maximum score of {result[Count1,1]}, Mimimum Scores of {result[Count1,2]}, and an average of {result[Count1,3]}") ;
            } 

        } //end of main

        //Method - getValidInt - To get a Valid Integer from the User
        static int getValidInt(string prompt, int minNum, int maxNum)
        {
            int validInt;
            Console.Write($"{prompt} between(including) minimum-{minNum}, maximum-{maxNum} : ");
            validInt=Convert.ToInt32(Console.ReadLine());
            while (validInt < minNum || validInt > maxNum || validInt % 1 != 0) 
            {
                Console.WriteLine("Enter Valid Number");
                Console.Write($"{prompt} between(including) minimum-{minNum}, maximum-{maxNum} : ");
                validInt=Convert.ToInt32(Console.ReadLine());
            }
            return validInt;
        } // end of getValidInt

        //Method - get2DInput - To get a Valid Integer from the User
        static String[,] get2DInput(int rowLength, int columnLength, String prompt1, String prompt2, int minNum, int maxNum)        
        {
            String[,] twoDimArray = new String [rowLength,columnLength];
            for (int innerCount=0; innerCount < rowLength; innerCount ++)
            {
                for (int outerCount=0; outerCount < columnLength; outerCount++)
                {                   
                    //Get the Student Name
                    if (outerCount == 0)
                    {
                        Console.Write($"Enter the {prompt1} :");
                        twoDimArray[innerCount,outerCount]=Console.ReadLine();                        
                    }
                    else //Get the Student Score
                    {
                        //  Console.Write($"{prompt2}{outerCount} :");
                         int Score = getValidInt($"{prompt2}{outerCount} :",minNum,maxNum);
                         twoDimArray[innerCount,outerCount]=Convert.ToString(Score);
                    }

                }//end of outer loop

            } // end of inner for loop

            return twoDimArray;

        } //end of Method get2DInput
        static String[,] getMinMaxAvg(String[,] arrayInput, int rowLen, int columnLen)
        {
            String [,] result = new String [rowLen,4];
            int total=0, average=0, totAverage=0;
            int min, max;
            for (int outer=0; outer < rowLen; outer++)            
            {
             min=101; max=0;   
             for (int inner=0; inner < columnLen; inner++)
              {
                if (inner == 0)
                {
                    result[outer,inner] = arrayInput[outer,inner];
                    total=0; average=0; min=101; max=0;
                    
                }
                else
                {
                    total=total + Convert.ToInt32(arrayInput[outer,inner]);
                    if (Convert.ToInt16(arrayInput[outer,inner]) < min)
                    {
                        min = Convert.ToInt16(arrayInput[outer,inner]);
                    }
                    else
                    {
                        max = Convert.ToInt16(arrayInput[outer,inner]); 
                    }

                }
              }
              result[outer,1]=Convert.ToString(max);
              result[outer,2]=Convert.ToString(min);
              average=total/(columnLen-1);              
              result[outer,3]=Convert.ToString(average);
               min=101; max=0;  
              
            }                        

            return result;

        } //get min,max,average
    } //end of class
} //end of namespace