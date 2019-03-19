using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook // Example of inheritance
    {

        public override GradeStatistics ComputeStatistics() //Instead of the Program.cs referencing the ComputeStatistics() method from Gradebook, it does it from here with the OVERRIDE key
        {
            Console.WriteLine("ThrowAwayGradeBook::ComputeStatics");
            float lowest = float.MaxValue;
            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            grades.Remove(lowest);
            
            return base.ComputeStatistics();
        }
    }
}
