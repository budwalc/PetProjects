using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker // I want gradebooks and throwawaygradebooks to inhert from here, and now I want GradeTacker to inherift from IGradeTracker
    {
        
        public abstract void AddGrade(float grade); //It has no implementation details
        public abstract GradeStatistics ComputeStatistics(); //removed VIRTUAL because abstracts don't need implementation details
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        protected string _name;
        public string Name //if you dont use autoimplement i.e get;set you have to put in a private field within the get block
        {
            get
            {
                return _name; //return the name that's already stored privately.
            }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Namme Cannot be null or empty");
                }//If the value of the string is NOT NULL or NOT EMPTY, advance to the next step.


                if (_name != value) // If the value (entered from the program.cs file) doesn't match with what's already stored for the private name field, advance to the next step.
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;               //the NameChanged delegate (as defined in the code below) will then STORE this is a variable i.e method(currentname, and the value entered from the program.cs file)
                    NameChanged(this, args);               //"this" is referring to itself within the object, so in this case its referring to GradeBook.cs, if you typed in this. you will see all members of the object class.
                }

                _name = value;

            }
        }


        public event NameChangedDelegate NameChanged; //Defined the instance of the NameChangedDelegate as "NameChanged" This will be referred in the public string name property, check above this code.
        // this has now been changed to include event. 
        // MAKE SURE TO INCLUDE "event NameChangedDelegate NameChanged" within the IGradeTracker.cs file!! Very Important


    }
}
