using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{

    public enum Type { Land, Water, Air }

    class Activities : IComparable<Activities>
    {

        //properties
        public string Activity { get; set; }
        public DateTime Date { get; set; }
        public Type Type { get; set; }
        public string Desc { get; set; }
        public decimal Cost { get; set; }


        //actors
        public Activities(string activity, DateTime date, Type type, string desc, int cost)
        {

            Activity = activity;
            Date = date;
            Type = type;
            Desc = desc;
            Cost = cost;

        }

        //methods
        public override string ToString()
        {

            return $"{Activity} - {Date.ToShortDateString()}";
          
        }

        //Sorts by date
        public int CompareTo(Activities other)
        {

            DateTime x = this.Date;
            DateTime y = other.Date;

            return x.CompareTo(y);

        }
    }
}
