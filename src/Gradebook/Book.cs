using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{get;}
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {//Create an abstract class (we can now use this base class to call addgrade depending upon requirement like inmemory,in file etc.)
        public Book(string name) : base(name)
        {

        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }
    
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book, IBook
    {
        public InMemoryBook (string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade) //override the abstract class
        {
            if(grade >= 0 && grade <= 100) 
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C': 
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;   
            }
        }

        public override event GradeAddedDelegate GradeAdded; 

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            foreach(var grade in grades)
            {
                result.Add(grade);
            }
            
            return  result;
        }

        public List<double> grades;
        
    }
}