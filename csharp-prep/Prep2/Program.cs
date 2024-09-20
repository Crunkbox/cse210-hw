using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string gradeNum = Console.ReadLine();
        int gradeScore = int.Parse(gradeNum);

        string letterGrade = "";

        if (gradeScore >= 90)
        {
            letterGrade = "A";
        }
        else if (gradeScore >= 80)
        {
            letterGrade = "B";
        }
        else if (gradeScore >= 70)
        {
            letterGrade = "C";
        }
        else if (gradeScore >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }
        
        int remainder = gradeScore % 10;
        string plusOrMinus = "";
        
        if (gradeScore > 93)
        {
            plusOrMinus = "";
        }
        else if (gradeScore >= 60)
        {
            if (remainder >= 7)
            {
                plusOrMinus = "+";
            }
            else if (remainder <= 3)
            {
                plusOrMinus = "-";
            }
            else
            {
                plusOrMinus = "";
            }
        }
        else
        {
            plusOrMinus = "";
        }

        Console.WriteLine($"You got a grade of {letterGrade}{plusOrMinus}.");

        if (gradeScore >= 70)
        {
            Console.WriteLine("You passed!!!");
        }
        else
        {
            Console.WriteLine("You failed. >:(");
        }
    }
}