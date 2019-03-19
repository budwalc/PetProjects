using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker // GradeBook is a Concrete Type
    {
        
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public override GradeStatistics ComputeStatistics() // When i implement ComputeStatistics() in Gradebook.cs if i want this method to provide an implementation for an abstract method in my base class, i have to remove virtual and use override.
        {
            Console.WriteLine("GradeBook::ComputeStatics");

            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade); // It uses a range hence why there are 2 arguments for max/min
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade); // It uses a range hence why there are 2 arguments for max/min
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count; //If there is no grades it will divide by 0, which will create runtime error
            return stats;
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);

        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }


        public override IEnumerator GetEnumerator()
        {
           return grades.GetEnumerator();
        }

        // Fortunately LISTS are also IEnumerable!!! =) All collections in .NET all implement the IEnumerable interface.
        protected List<float> grades; //Changed from PRIVATE to PROTECTED, private means only members in the same class can access this list, if its protected you can access from a derived class or within same class. Now this is "PROTECTED" I can access this in the ThrowAwayGradeBook.cs file 

       


    }
}
