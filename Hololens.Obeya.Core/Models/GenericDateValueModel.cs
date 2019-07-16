using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hololens.Obeya.Core.Models
{
    public class GenericDateValueModel
    {
        public GenericDateValueModel(DateTime date, int value)
        {
            Date = date;
            Value = value;
        }

        public DateTime Date { get; set; }

        public int Value { get; set; }
    }
}
