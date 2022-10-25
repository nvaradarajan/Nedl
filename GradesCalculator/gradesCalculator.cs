//gradesCalculator
//date: Sep 16,2022
//author: Nithya
//Scope: Calculate Grades of Students
//Stories:
//      #1 Get the Count of the Students min=1 max=100
//      #2 Get 1. Name of the Student 2. Five Homework Grades 3. Three Quiz Grades 4. Two Exam Grades gradesMin=0 gradesMax=100
//      #3 Grade Average is 50% of Homework Average plus 30% of Quiz Grades plus 20% of exam grades
//      #4 Final Grade Average 90% or greater, it is an A; 80% or better is a B; 70% or better is a C; 60% or better is a D; and anything less than 60% is an F.
//      #5 display the student's name, homework average, quiz average, exam average, final average and final grade.
using System;
namespace gradesCalculator
{
    class program
    {
        static void Main()
        {
            
            Console.WriteLine("Welcome to grades calculator");   //Welcome Message

//Story #1 Get the Count of the Students min=1 max=100
            const int studentCountMin = 1;  //Constant Minimum Student Count for Story #1
            const int studentCountMax = 10; //Constant Maximum Student Count for Story #1
            int studentCount;               //Variable for Count of Students
            //Method getValidInt - To get a valid Student Count from the user within the boundary of studentCountMin and studentCountMax 
            studentCount=getValidInt($"Enter the count of Students, Minimum={studentCountMin}, Maximum = {studentCountMax} : ",studentCountMin,studentCountMax);

//Story #2 Get 1. Name of the Student 2. Five Homework Grades 3. Three Quiz Grades 4. Two Exam Grades gradesMin=0 gradesMax=100
//Story #3 Grade Average is 50% of Homework Average plus 30% of Quiz Grades plus 20% of exam grades
            const int studentGradeMin = 0;  //Constant Minimum Student Count for Story #1
            const int studentGradeMax = 100; //Constant Maximum Student Count for Story #1            
            const int homeWorkCount=5, quizCount=3, examCount=2; //Constant for number of subjectgraded
            const double homeWorkGradeXplier=0.5,quizGradeXplier=0.3,examGradeXplier=0.2; //Constant for pecentage for each subject
            string [] studentName=new string[studentCount];        //Array for Student count 
            double [] homeWorkGradeFinal=new double[studentCount]; //Array for homeWork grades
            double [] quizGradeFinal=new double[studentCount];     //Array for quiz grades 
            double [] examGradeFinal=new double[studentCount];     //Array for exam grades
            double [] gradeFinal=new double[studentCount];         //Array for final grades             
            string [] grade=new string[studentCount];
            
            //for loop to calculate homeWorkGrade/QuizGrade/examGrade and FinalGrade using Method getGradeFinal
            for (int studentCounter=0;studentCounter <= studentCount - 1; studentCounter++)
            {
                Console.WriteLine();
                Console.Write($"Enter Students {studentCounter+1} Name : ");
                studentName[studentCounter]=Console.ReadLine()!;
                Console.WriteLine();
                homeWorkGradeFinal[studentCounter]=getGradeFinal(studentName[studentCounter],"homework ",homeWorkCount,homeWorkGradeXplier,studentGradeMin, studentGradeMax); 
                quizGradeFinal[studentCounter]=getGradeFinal(studentName[studentCounter],"quiz ",quizCount,quizGradeXplier,studentGradeMin, studentGradeMax); 
                examGradeFinal[studentCounter]=getGradeFinal(studentName[studentCounter],"exam ",examCount,examGradeXplier,studentGradeMin, studentGradeMax); 
                gradeFinal[studentCounter]=homeWorkGradeFinal[studentCounter] + quizGradeFinal[studentCounter] + examGradeFinal[studentCounter];
            };
//story #4 Final Grade Average 90% or greater, it is an A; 80% or better is a B; 70% or better is a C; 60% or better is a D; and anything less than 60% is an F.
//story #5 display the student's name, homework average, quiz average, exam average, final average and final grade.
            //for loop to display homeWorkGrade/QuizGrade/examGrade and FinalGrade using Method getGradeFinal            
            for (int studentCounter=0;studentCounter <= studentCount - 1; studentCounter++)
            {
                Console.WriteLine();
                Console.WriteLine($"Grade summary of {studentName[studentCounter]}");
                Console.WriteLine($"homework grade :  {homeWorkGradeFinal[studentCounter]}% ; quiz grade : {quizGradeFinal[studentCounter]}% ; exam grade : {examGradeFinal[studentCounter]}% ; ");
                Console.WriteLine($"total grade percent :  {gradeFinal[studentCounter]}%"); 
                grade[studentCounter]=getGrade(gradeFinal[studentCounter]);
                Console.WriteLine($"{studentName[studentCounter]} has obtained {grade[studentCounter]}");                                
                Console.WriteLine();                
            };


        } //end of Main

        //getValidInt Method displays the prompt send in the main method and validates the user entry is within the limit provided in the main method
        static int getValidInt(string prompt,int min,int max) //Pass prompt, Minimum and Maximum Integer from the user
        {
            int count;
            do
            {
                Console.Write(prompt);                
                count = Convert.ToInt32(Console.ReadLine());
                if (count < min || count > max)
                {
                    Console.WriteLine($"Please enter a valid entry between {min} and {max}");
                };
            } while (count < min || count > max); //repeat the loop until valid entry is entered
            return count;
        } //end of getValidCount 

        //Method getGradeFinal gets the student name and marks from the user (mark is validated to be in the minumum and maximum limit passed). 
        //Marks were aggregated grade is calculated based on the grade percent passed.
        //grade percent is sent back to main method
        static double getGradeFinal(string studentName, string subject, int subjectCount, double subjectGradeXplier, int studentGradeMin, int studentGradeMax) //pass studentName, subject name, subject count, gradepercent, minimumGrade and maximum Grade
        {
            Console.WriteLine ($"Please enter the grades for {subject} , Minimum={studentGradeMin}, Maximum={studentGradeMax}");
            int subjectGrade=0, subjectTotal=0;
            double subjectAvg=0.0, subjectGradeFinal;
            for (int count=1; count <= subjectCount  ; count ++ )
            {
                subjectGrade=getValidInt($"Enter {studentName} {subject} {count} : ",studentGradeMin,studentGradeMax); //use getValidInt method to get a valid mark from user
                subjectTotal = subjectTotal + subjectGrade; //aggregate the mark entered
            };
            subjectAvg = (double) (subjectTotal/subjectCount); //average the mark entered
            subjectGradeFinal=subjectAvg * subjectGradeXplier; //calculate the grade percent
            Console.WriteLine ();
            return subjectGradeFinal;
        } //end of getGradeFinal
        
        static string getGrade(double finalGrade)
        {
            string gradeVar=" ";
            if (finalGrade >= 90 ) // if finalGrade is greater than 90%, student is given GRADE-A
                {
                    gradeVar="GRADE A";                    
                };                
                if (finalGrade >= 80 &&  finalGrade < 90) // if finalGrade is between 80% and 89%, student is given GRADE-B
                {
                    gradeVar="GRADE B";                    
                };                
                if (finalGrade >= 70 && finalGrade < 80 ) // if finalGrade is between 70% and 79%, student is given GRADE-C
                {
                    gradeVar="GRADE C";                    
                };                
                if (finalGrade >= 60 && finalGrade < 70 ) // if finalGrade is between 60% and 79%, student is given GRADE-D
                {
                    gradeVar="GRADE D";                    
                };                
                if (finalGrade < 60 ) // if finalGrade is less than  60%, student is given GRADE-F
                {
                    gradeVar = "GRADE F";                    
                };    
                return gradeVar;   

        } //end of getGrade

    } //end f class program 

} //end of namespace

