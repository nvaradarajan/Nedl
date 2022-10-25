using System;
namespace Rest{
class Rest
{
 string restName=" ";
 int restRating=0;

    public String RestName()
    {
        get {return restName;}
        set {restName="Olive Garden";}
    }

    public int RestRating()
    {
       get {return restRating;}
       Set {restRating=5;}
    }

} //end of class
}