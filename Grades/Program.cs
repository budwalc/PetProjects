using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args) // This is the main entry
        {
            IGradeTracker book = CreateGradeBook(); //Intialises the ThrowAwayGradeBook Class object.

            book.NameChanged += OnNameChanged; // So this is not procedural, this is an EVENT, this is just saying..."HEY! If I see something from this main program that tries to change the name of the current GradeBook name, I'll invoke the method I just created outside of main and will tell the world!!
            //book.NameChanged += OnNameChanged2; //So i've trimmed the code after i put EVENTS type in GradeBook.cs to my delegate, so now I don't have to type in the whole new DelagateNameChanged(method)

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book); // This will invoke the method that will 
        }

        private static IGradeTracker CreateGradeBook() // Changed from GradeBook to GradeTracker to explain abstracts
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book) // Changed from GradeBook to GradeTracker to explain abstracts
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade); //Type Converstion, all these results are float types, but because i've explcitly casted as an int, it will use the int parameter in the method WRITERESULT
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)  // Changed from GradeBook to GradeTracker to explain abstracts
        {
            using (StreamWriter outputfile = File.CreateText("grades.txt")) //this is useful for unmanageble resource allocation/deallocation
            {
                book.WriteGrades(outputfile); //only use using, if you can use dispose method
            }
        }

        private static void AddGrades(IGradeTracker book) // Changed from GradeBook to GradeTracker to explain abstracts
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)  // Changed from GradeBook to GradeTracker to explain abstracts
        {
            try
            {
                Console.WriteLine("Enter name");
                book.Name = Console.ReadLine();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // our delegate we created to store the method(oldname and newname) from GradeBook.cs will be using this method as a template in the main body code.
        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:f}", description, result);
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine("{0}: {1}", description, result);
        }

        private class file
        {
        }
    }
}
