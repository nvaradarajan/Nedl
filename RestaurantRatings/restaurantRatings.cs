//Date - Sep 23, 2022
//author - Nithya
//Scope - Display Menu with folling options O/S/C/R/U/D/Q
//        O - Open the user's list of restaurants
//        S - Save the user's list of restaurants
//        C - Add a restaurant and rating
//        R - Print a list of all the restaurants and their rating
//        U - Update the rating for a restaurant
//        D - Delete a restaurant
//        Q - Quit the program    

using System;
namespace restaurantRatings
{
    class program
    {
        static void Main()
        {
            //Constants
            const String quitMessage="Thank you for using Restaurant Rating Application";
            const String filename=@"C:\Users\NVaradarajan\Desktop\Nedl\RestaurantRatings\RestaurantList.txt";
            const int resDetails=3, resCount=05;
            
            //Variables
            bool quitProgram=false;
            String exitRecEntry="Y";
            String recordin=" ";
            int counter=0;
            String[,] resArray = new String[resCount,resDetails];
            resArray[0,0]="Number  ";
            resArray[0,1]="Restaurant Name                 ";
            resArray[0,2]="Ratings[1-5]";
            String arrData;
            int row=0,column=0;
            // int col1Len=6,col2Len=32,col3Len=1;

            //Display the MainMenu 
            displayMainMenu();
            String validOptions = "Enter the valid option O/S/C/R/U/D/Q/M; Q-Quit the Program; M-Display the menu in detail : ";
            String menuOpt=" ";
            var menuList = new List<string>() {"O", "S", "C", "R", "U", "D", "Q","M"};            
            //get Valid User Entry
            menuOpt=promptUserMenuopt(menuList,validOptions);

            //loop thru the menu unitl User Quits
            do
            {            
                switch (menuOpt)
                {
                    //Display data from the file
                    case "O":
                        counter=1;                                          //counter is initialized
                        using (StreamReader sr = File.OpenText(filename))   //Open the file
                        {                                                        
                            while ((recordin=sr.ReadLine()!) != null)        //Read the file and check for null
                            {                
                                if (recordin.Equals(' '))
                                {
                                    if (counter <= 2) 
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("No Entries in the file");
                                        Console.WriteLine();
                                    }
                                }
                                else
                                {               
                                Console.WriteLine(recordin);                //display the file in console
                                counter ++;                                 //increase the counter
                                }
                            }                            
                                      
                        }
                        menuOpt=promptUserMenuopt(menuList,validOptions); //display the user prompt
                        break;

                    //Display the Main Menu
                    case "M":
                        displayMainMenu();
                        //get Valid User Entry
                        menuOpt=promptUserMenuopt(menuList,validOptions); //display the user prompt
                        break;

                    //Save the file from array
                    case "S":
                        if ((!File.Exists(filename)))                     //check if file does not exists
                        {
                            using (FileStream fs = File.Create(filename)); //Creates file if file not exists

                        }
                        else
                        {
                            File.Delete(filename);
                            using (FileStream fs = File.Create(filename));                            
                            using StreamWriter file = new(filename); //open the file in write mode
                            
                            for(row=0;row<resCount;row++)        //Loop for restaurant names  
                            {
                                arrData=" ";
                                for (column=0;column < resDetails; column++)   //Loop for restaurant Details
                                {
                                    if (resArray[row,column] != null)                                    
                                    {   
                                        arrData=String.Concat(arrData,"  ");                                                                                   
                                        arrData=String.Concat(arrData,resArray[row,column]);                                        
                                        arrData=String.Concat(arrData,"     ");
                                    }
                                    
                                } // end of column loop
                                if (arrData != null)
                                {
                                    file.WriteLineAsync(arrData);                                    
                                }                                                          
                            }//end of row loop    
                            Console.WriteLine(" Array Data Saved to File");
                        }
                        //return to main menu
                        menuOpt=promptUserMenuopt(menuList,validOptions); //display the user prompt
                        break;

                    //Add a Restaurant and Rating to the array
                    case "C":
                        exitRecEntry="Y"; //Initialize Exit Record Entry to Y to loop for the first time
                        for(row=0;row<resCount;row++)        //Loop for restaurant names  
                            {
                                arrData=" ";                                                    
                                for (column=0;(column < resDetails) ; column++)   //Loop for restaurant Details
                                {                            

                                    if (resArray[row,column] == null && exitRecEntry == "Y") //loop to validate end of record
                                    {
                                        if (column==0)  //Add the Counter
                                        {                                            
                                            counter=(int)(row);
                                            resArray[row,column]=Convert.ToString(counter);
                                            arrData=arrData + resArray [row,column]; 
                                        }
                                        if (column==1) // get the Restaurant Name
                                        {
                                            Console.WriteLine($"Enter the {counter} Restaurant Name :");
                                            resArray[row,column]=Console.ReadLine()!;
                                            arrData=arrData + resArray [row,column]; 
                                        }
                                        if (column==2) //get the Rating
                                        {
                                            Console.WriteLine($"Enter the {resArray[row,column-1]} Rating :");
                                            resArray[row,column]=Console.ReadLine()!;
                                            arrData=arrData + resArray [row,column]; 
                                            
                                            //Check whether User wants to Continue Adding records
                                            Console.WriteLine ("Do you want to Continue-Enter Y : ")    ;
                                            exitRecEntry=Console.ReadLine()!; 
                                            exitRecEntry=exitRecEntry.ToUpper();                                                                                    
                                        }
                                                                                                              
                                    }
                                    if (exitRecEntry != "Y")
                                    {
                                        break;
                                    }
                                    
                                } // end of column loop
                                if (exitRecEntry != "Y")
                                {
                                    break;
                                }
                              
                            }    //end of row loop
                        //return to main menu   
                        menuOpt=promptUserMenuopt(menuList,validOptions); //display the user prompt
                        break;

                    //Print the list of all the restaurants from the array
                    case "R":
                        readArray(resCount,resDetails, resArray);
                        //return to main menu
                        menuOpt=promptUserMenuopt(menuList,validOptions); //display the user prompt
                        break;

                    //Update rating of a restaurant in the array
                    case "U":
                        readArray(resCount,resDetails, resArray); //display the array
                        int updRecord=0;     
                        //get the valid record number that needs to be Updated    
                        do{
                            Console.WriteLine ("Enter the Valid Record Number you want to update Rating: ");
                            updRecord=Convert.ToInt32(Console.ReadLine()!);
                        } while ((updRecord >= resCount) || (resArray[updRecord,2] == null));
                                                
                        Console.WriteLine ($"Enter the New Rating for Record Number {updRecord}: ");
                        resArray[updRecord,2]=Console.ReadLine()!; //get the new rating and update the record
                        Console.WriteLine ($"Rating Updated for Record Number {updRecord} ");
                        Console.WriteLine ($"Here is the updated Record ");
                        readArray(resCount,resDetails, resArray); //display the array
                         
                        //return to main menu                        
                        menuOpt=promptUserMenuopt(menuList,validOptions); //display the user prompt
                        break;

                    //Delete rating of a restaurant in the array
                    case "D":
                        Console.WriteLine ("Work in Progress");
                        readArray(resCount,resDetails, resArray); //display the array
                        int delRecord=0;     
                        //get the valid record number that needs to be deleted    
                        do{
                            Console.WriteLine ("Enter the Valid Record Number you want to update Rating: ");
                            delRecord=Convert.ToInt32(Console.ReadLine()!);
                        } while ((delRecord >= resCount) || (resArray[delRecord,2] == null));
                        //for{row=delRecord}

                        //return to main menu
                        menuOpt=promptUserMenuopt(menuList,validOptions); //display the user prompt
                        break;


                    //Quit the Menu
                    case "Q":
                        Console.WriteLine();
                        Console.WriteLine(quitMessage);
                        Console.WriteLine();
                        quitProgram=true;
                        break;

                    default:                        
                        menuOpt=promptUserMenuopt(menuList,validOptions); //display the user prompt
                        break;
                }
            } while (quitProgram==false);
            
            //Test
            // Console.WriteLine(menuOpt);
            

        } // end of main
        
        static void displayMainMenu()
        {
            Console.WriteLine(" Welcome to Restaurant Ratings Application ");            
            Console.WriteLine("Please find the menu options for you to choose");
            Console.WriteLine("");
            Console.WriteLine("O - Open the user's list of restaurants");
            Console.WriteLine("S - Save the user's list of restaurants");
            Console.WriteLine("C - Add a restaurant and rating");
            Console.WriteLine("R - Print a list of all the restaurants and their rating");
            Console.WriteLine("U - Update the rating for a restaurant");
            Console.WriteLine("D - Delete a restaurant");
            Console.WriteLine("Q - Quit the program");

        } // end of displayMainMenu
        
        
        //Method promptUserMenuopt
        //Prompt the user and get the valid user entry from the menu list
        static string promptUserMenuopt(System.Collections.Generic.List<string> menuList,string validOptions)
        {
        string menuOpt;
        bool validMenu=false;
        do
            {               
               Console.Write(validOptions);
               menuOpt=Console.ReadLine()!;                         //Read the user entry
               menuOpt=menuOpt.ToUpper();                           //convert the user entry to uppercase
               if (menuList.Contains((menuOpt))) {validMenu=true;}  //validMenu is set to true if menuOpt is in menuList
            } while (validMenu == false);    
        return menuOpt;
        } //end of method userPrompt
        static void readArray(int resCount,int resDetails, string[,] resArray)
        {
            for(int row=0;row<resCount;row++) //Loop for Resturant Names                        
            {
                String arrData=" ";
                for (int column=0;(column < resDetails) ; column++)   //Loop for restaurant Details
                {
                    arrData=arrData + "   " + resArray[row,column]; //Concatenate the column entries for a restaurant
                }
                Console.WriteLine(arrData); // Display the Results

            }

        } //End of method read array

    } // end of class
    
} // end of namespace