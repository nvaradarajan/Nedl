// Brought to you by Brian, Geoff, Nithya
// Created on 09/14/2022
using System;
    namespace Accumulator
    {
        class Program
        {
            static void Main(string[] args)
            {              
            // Get the count of Numbers(Integers) from the User. 
                int numberOfItems = 0;
                string trueInt;
                do
                {
                    Console.Write("Please enter a number between 2 and 10 (including 2 and 10) : ");
                    String? readInput = (Console.ReadLine());
                    trueInt = isInt(readInput);            
                    Console.WriteLine ("is Int Output is {0}", trueInt);
                    if (trueInt == "true") && (numberOfItems >= 2 && numberOfItems <= 10 )

                        {
                        numberOfItems = Convert.ToInt32(readInput);
                        }
                    else
                    // Throw Error if number is not between 2 and 10 (Including 2 and 10)                    
                        {
                            Console.WriteLine("The number you entered is invalid.");
                        }
                } while ((numberOfItems < 2 || numberOfItems > 10) && (trueInt == "false" ));


            // Get the Numbers(Integers) from the User.
            int totalNumber = 0;
            double enterNumber=0;
            double remainder;            
            int counter=1;
            int getNumber=0;
            do
                {
                    Console.Write("Please enter number {0} : ", counter);
                    enterNumber = Convert.ToDouble(Console.ReadLine());
                    remainder = enterNumber % 1;
                    if (remainder == 0)
                    //Number entered is an Integer - Sum the Numbers
                    {
                        getNumber = Convert.ToInt32(enterNumber);
                        totalNumber=totalNumber+getNumber;
                        counter++;
                    }
                    else
                    {
                        // Throw error if the received numbers were not integers
                        Console.WriteLine("Please enter a whole number");
                    }
                }while (counter <= numberOfItems);


             // Display the Count of Numbers and Total of the numbers entered            
             Console.WriteLine("Total of the {1} numbers entered : {0} ", totalNumber, numberOfItems);              
            } //End Main


            static string isInt(string inputValue)
            {        
                double Value = Convert.ToDouble(inputValue);
                double remainder = Value%1;
                if (remainder == 0)
                {
                    string intYes="true";
                    return intYes;
                }
                else
                {
                    string intYes="false"; 
                    return intYes;       
                }

                
            } //End isInt

        } //End class

    }  // End namespace