using System;

namespace Gradebook
{
    public class Statistics
    {
        public Statistics()
        {
            Highest = double.MinValue;
            Lowest = double.MaxValue;
            Sum = 0;
            Count = 0;
        }
        public void Add(double number)
        {
            Sum+=number;
            Count+=1;
            Highest = Math.Max(Highest,number);
            Lowest = Math.Min(Lowest, number);
        }
        public double Average { 
            get
            {
                return Sum/Count;
            }
        }
        public double Highest { get; set; }
        public double Lowest { get; set; }
        public char Letter 
        { 
            get 
            {
                switch(Average)
                {
                    case var d when d >= 90.0 :
                        return 'A';
                    case var d when d >= 80.0 :
                        return 'B';
                    case var d when d >= 70.0 :
                        return 'C';
                    case var d when d >= 60.0 :
                        return 'D';
                    default :
                        return 'F';
                }
            }
        }
        public double Sum { get; set; }
        public int Count { get; set; }
    }
}