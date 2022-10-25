using System;

namespace Rest
{

    class program{
    static void Main(string[] args)
    
    {
        Rest myRest1 = new Rest();    
        Console.WriteLine(myRest1.restName + " " + myRest1.restRating);        

        Rest myRest2 = new Rest(); 
        myRest2.restName="Olive Garden";
        myRest2.restRating=4;
        Console.WriteLine(myRest2.restName + " " + myRest2.restRating);        
      
    }
    }
}

    
