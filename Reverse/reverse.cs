//date      Sep 15,2022
//author    Nithya
//Scope     Print the number in the reverse order entered
using System;
namespace reverse
{
    class program
    {
        static void Main()
        {
        // get the count of nos
        int inputCount=0;
        do
        {
            Console.Write("enter the count of nos (number greater than 0): ");
            inputCount=Convert.ToInt32(Console.ReadLine());            
        } while (inputCount <= 0);

        //get the nos into an array
        string[] inputData={"0"};
        int arrayCounter, inputOrder=1;
        for (arrayCounter=inputCount; arrayCounter <= inputCount; arrayCounter-- )
        {
             Console.Write($"enter the number {inputOrder}: ");
             inputData[arrayCounter]=Console.ReadLine()!;             
        };

        // display the number in the reverse order using for loop
        for (arrayCounter=1; arrayCounter > inputCount; arrayCounter++ )
        {
             Console.Write($"number {arrayCounter} : {inputData[arrayCounter]} ");         
        };

        }//end of main
    }//end of class program
} //end of namespace