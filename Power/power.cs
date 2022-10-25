//Date Created - Sep 15,2022
//Author Keith,Peter,Nithya
//
//Scope: To create a method that takes base and exponent from the user and provides the result (base to the power of exponent). 
//        All datatype in Integer and base and exponent is expected to greater than 1
//
//Main Program
//Step 1 - Call the mehod GetUseInput and get the base and exponent user input
//Step 2 - call the method Power to calculate the base to the power of exponent and get the result
//Step 3 - Prompt user to continue or quit
//Step 4 - Repeat Step1 if the User wants to Continue, else quit the process
//
//Method - Power
//Step 5 - Get the base and exponent
//Step 6 - Calculate the power using "for" loop
//step 7 - return the result
//
//Method - GetUsetInput 
//Step 8 - Receive the Prompt and Low Value
//Step 9 - Send the Prompt and get the user Input
//Step 10 - Validate the user  entry is greater than or equal to the lowValue 
//step 11 - return the user entry

using System;
namespace power
{    class Program
    {
     static void Main()
     {
        int baseNumber, expNumber, result ; //Variable to get the base, exponent from user and variable result will be base to the power of exponent
        String varContinue = "Y";             //Variable to Prompt user to continue 
        do
        {
            baseNumber = GetUserInput("Enter the base number : ", 1);     // Call GetUserInput Method to get the base number
            expNumber = GetUserInput("Enter the exponent number : ", 1);  // Call GetUserInput Method to get the exponent number
            result=Power(baseNumber,expNumber);                           // Call Power Method to calculate the result
            Console.WriteLine("{0} to the power of {1} is {2} ", baseNumber, expNumber, result); // Display the result in the console
        
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
        int result=1;                                           // variable result initialized to 1 to handle the multiplication       
        for (int counter=1; counter <= expValue; counter ++)   //for loop to repeat exponent times
        {
            result = result * baseValue;                       //multiply result with base value and save the result
        }
        return (result);                
     } // end method Power

    //Method GetUserInput 
     static int GetUserInput(string prompt,int lowValue)   // Method GetUserInput gets the prompt and lowValue
     {
        int input;
        do{
            Console.Write(prompt);                         // Send the Prompt to the User
            input = Convert.ToInt32(Console.ReadLine());   // Read the User Input
            if (input < lowValue)                          //Check the User Input is less than the low Value 
            {
                Console.WriteLine("Please enter a valid number greater than or equal to {0}" ,lowValue); //Send error when User input is less than the low Value
            }
        } while (input < lowValue);              // Repeat the loop when user enter value less than lowvalue
        return input;                            // return the user input 
     } // end method GetUserInput
    } // end program
} //end namespace
