using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDatabaseCancellationDemo.dto
{
    class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        public int Titles { get; set; }
        public string Status { get; set; }
        public DateTime ValueDate { get; set; }
    }
}
