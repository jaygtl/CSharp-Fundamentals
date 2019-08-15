using System;
using System.IO;

namespace Gradebook
{
    public class DiskBook : Book
    {
        private const string Path = "E:'\'source'\'Gradebook'\'Grades";

        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var write = File.AppendText($"{Name}.txt"))
            {
                write.WriteLine(grade);
                if(GradeAdded !=null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
             using(var reader = File.OpenText($"{Name}.txt"))
            {
                var data = reader.ReadLine();
                while(data !=null)
                {
                    var number = double.Parse(data);
                    result.Add(number);
                    data = reader.ReadLine();
                }
            }
            return result;
        }
    }
}