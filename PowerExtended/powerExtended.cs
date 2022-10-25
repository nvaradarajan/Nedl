//Date Created - Sep 15,2022
//Author Nithya
//
//Scope: To create a program that takes base exponent1 and exponent2 from the user, exponent2 should be greater than exponent1. 
//       Result should range from base to the power of exponent1 thru base to the power of exponent2. 
//       All datatype in Integer and base and exponents are expected to be greater than 1
//

using System;
namespace power
{    class Program
    {
     static void Main()
     {
        //Main Program
        //Call the mehod GetUserInput and get the base, exponent1 and exponent2 input from user. Repeat exponent2 until it is greater than exponent1.
        //call the method Power to calculate the base to the power of exponent and display the result. Repeat the method for exponent1 thru exponent2.
        //Prompt user to continue or quit
        //Repeat Step1 if the User wants to Continue, else quit the process
        const int min=1;
        int baseNumber, expNumber, expNumber1, expNumber2, result, expCounter ; //Variable to get the base, exponent from user and variable result will be base to the power of exponent
        String varContinue = "Y";             //Variable to Prompt user to continue 
        do
        {
            baseNumber = GetUserInput("Enter the base number : ", min);     // Call GetUserInput Method to get the base number
            expNumber1 = GetUserInput("Enter the first exponent number(lower) : ", min);  // Call GetUserInput Method to get the exponent number
            expNumber2 = GetUserInput($"Enter the second exponent number(Higher) - Number should be greater than {expNumber1}: ", expNumber1);  // Get the second exponent number, it should be greater than first exponent number                nameof

            //call to Method Power repeated from expNumber1 thru expNumber2
            for (expCounter=expNumber1; expCounter <= expNumber2; expCounter ++)
            {
                expNumber=expCounter;
                result=Power(baseNumber,expCounter);                           // Call Power Method to calculate the result
                Console.WriteLine($"{baseNumber} to the power of {expCounter} is {result} "); // Display the result in the console
            }
        
            //Check if the user like to Continue
            Console.WriteLine();  
            Console.Write("Do you want to Continue ? Enter Y :");  
            varContinue = Console.ReadLine()!.ToUpper(); //Read the user continuation entry , ! after ReadLine is Null Forgiving , Convert the entry to Upper Case
            Console.WriteLine();  

        } while (varContinue == "Y");

     } //end Main

    //Method Power
     static int Power(int baseValue,int expValue)               //Method Power receiving base and exponent value
     {
        //Pass the base and exponent
        //Calculate the power using "for" loop
        //return the result
        int result=1;                                           // variable result initialized to 1 to handle the multiplication       
        for (int counter=1; counter <= expValue; counter ++)   //for loop to repeat exponent times
        {
            result = result * baseValue;                       //multiply result with base value and save the result
        }
        return (result);                
     } // end method Power

    //Method GetUserInput 
     static int GetUserInput(string prompt,int min)   // Method GetUserInput gets the prompt and lowValue
     {
        //Pass the Prompt and minimum Value
        //get the user Input
        //Validate the user  entry is greater than or equal to the lowValue 
        //return the user entry

        int input;
        do{
            Console.Write(prompt);                         // Send the Prompt to the User
            input = Convert.ToInt32(Console.ReadLine());   // Read the User Input
            if (input <= min)                          //Check the User Input is less than the low Value 
            {
                Console.WriteLine($"Please enter a valid number greater than {min}"); //Send error when User input is less than the low Value
            }
        } while (input <= min);              // Repeat the loop when user enter value less than lowvalue
        return input;                            // return the user input 
     } // end method GetUserInput
    } // end program
} //end namespace
