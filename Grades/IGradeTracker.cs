using System.IO;
using System;
using System.Collections;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable // Within Interfaces you cannot use access modifiers for example public/private etc. Also these members are practically virtual so I can remove the ABSTRACT keyword
    {
        void AddGrade(float grade); 
        GradeStatistics ComputeStatistics(); 
        void WriteGrades(TextWriter destination);
        string Name { get; set; }
        event NameChangedDelegate NameChanged;
    }
}