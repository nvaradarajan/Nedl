using System;
namespace crud
{
    class program
    {
        static void Main()
        {
            // App - fallNedlNamelist - User Menu
            Console.WriteLine(" ************* Fall NEDL Name List ************");
            Console.WriteLine("     R - Read the 'Fall NEDL Name List' ");
            Console.WriteLine("     A - Add names to 'Fall NEDL Name List' ");
            Console.WriteLine("     U - Update names to 'Fall NEDL Name List' ");
            Console.WriteLine("     D - Delete names to 'Fall NEDL Name List' ");
            Console.WriteLine(" **********************************************");
            
            // Get the user entry
            String menuOpt = " ";
            Console.WriteLine();
            Console.Write("Enter your choice : ");
            menuOpt=Console.ReadLine();
            menuOpt=menuOpt.ToUpper();

            String filename = "Names.txt";
            String file1=@"C:\Users\NVaradarajan\Desktop\Nedl\Names.txt";
            bool recordDisplay=false;
            bool fileCreated=false;
            bool fileLoaded=false;
            const String rootFolder=@"C:\Users\NVaradarajan\Desktop\Nedl";
            int recordCount=0;


            //Read the file and get Number of records in the file
            if (menuOpt == "R")
            {                                   
                recordCount=readFile(file1,true);            
            };

            //Add Record to the file
            if (menuOpt == "A")              
            {
               //get the count of new names
                Console.Write ("Enter the count of names to be entered : ");
                int newCount = Convert.ToInt32(Console.ReadLine());

                //get the current record count                              
                recordCount=readFile(file1,false);       
                    
                //Create Array based on the new record count
                int arrayCount=recordCount+newCount;                    
                String[] inputFileArray = new String[arrayCount];
                
                //Load Array from file and user
                inputFileArray=loadArray(file1,arrayCount);                

                //Load File from Array
                fileLoaded=fileLoadfromArray(file1,inputFileArray,menuOpt,recordCount);
                  
                //Display File                 
                if (fileLoaded == true)
                { 
                    Console.WriteLine ("New Records were successfully Added. Here is the final list");                    
                    recordCount=readFile(file1,true); 
                }
                else
                {
                    Console.WriteLine ("New Records were not Added. Contact Admin");
                } ;   
            }                    

            if (menuOpt == "U")
            {
                int recordNumber=0;                
                //get the current record count                              
                recordCount=readFile(file1,true);
                
                do
                {
                Console.Write ("Enter the Record Number to be Updated from the list : ");
                recordNumber=Convert.ToInt32(Console.ReadLine());                

                } while (recordNumber > recordCount);

                //Load Array from file and user
                String[] inputFileArray = new String[recordCount];
                inputFileArray=loadArray(file1,recordCount);  
                Console.Write($"Enter the new name for {inputFileArray[recordNumber-1]} : ");
                inputFileArray[recordNumber-1]=Console.ReadLine();
            //     //Load File from Array
                fileLoaded=fileLoadfromArray(file1,inputFileArray,menuOpt,recordCount);
                recordCount=readFile(file1,true);  
            }

        }//end of main

        //Method Read File and get the record Count

        static int readFile(String file1,bool display) //pass filename and display switch =true/false
        {
            String[] fileOut=new String[10];
            String recordIn=" ";
            int recordCount=0;
            int count=0;
            // read file using object StreamReader into pointer sr
            using (StreamReader sr = File.OpenText(file1))
            {
                Console.WriteLine();
                while ((recordIn=sr.ReadLine()) != null)
                {
                    if (display == true)
                    {
                        Console.WriteLine($"Record Number: {++count} - {recordIn}");
                    }
                    recordCount ++;
                }
                Console.WriteLine();
                if (display == true)
                {
                    Console.WriteLine($"Record Count is : {recordCount}");
                }    
                return recordCount;

            }
        } //end of readFile

        //Method Load Array
        static String[] loadArray(String file1,int arrayCount)
        {
            String[] fileArray =new String [arrayCount];
            String recordIn=" ";
            int index=0,counter=0;
            using (StreamReader sr=File.OpenText(file1))
            {                
                while ((recordIn=sr.ReadLine()) != null) 
                {
                    fileArray[index]=recordIn;
                    index ++;
                }
            }                        
            for (counter=index; counter < fileArray.Length; counter++)
            {
                Console.Write($" Add Name #{counter+1} : ");
                fileArray[counter]=Console.ReadLine();
            };  
            
            return fileArray;

        } //end of load array

        static bool createFile(String rootFolder, String filename)
        {
            bool fileCreated = false;
            bool fileDeleted = false;
            try
            {
                if (File.Exists(Path.Combine(rootFolder, filename)))
                {
                    File.Delete(Path.Combine(rootFolder, filename)); 
                    fileDeleted = true;
                }
                if (fileDeleted == true)
                {
                    File.Create(Path.Combine(rootFolder,filename));
                    fileCreated = true;
                }

            }
            catch(IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
            return fileCreated; 

        } //end of create file

        //Method File Load from Array
        static bool fileLoadfromArray(String file1, String[] fileArray, String menuOpt, int recordCount)
        {            
            bool fileLoaded=false;                          
            // for(int counter=recordCount; counter < fileArray.Length; counter++)
            // {
            //     using StreamWriter file = new(file1, append: true);
            //     file.WriteLineAsync(fileArray[counter]);
            //     fileLoaded=true;
            // };                     
            File.WriteAllLines(file1,fileArray);                       
            fileLoaded=true;
            return fileLoaded;

        }//end of fileLoadFromArray

    } //end of class

} //end of namespace