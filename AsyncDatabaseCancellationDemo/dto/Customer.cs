using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDatabaseCancellationDemo.dto
{
    class Customer
    {
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public string EyeColor { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string EMail { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, CustomerId);
        }
    }
}
