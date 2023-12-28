using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Table("Order")]
    internal class Order
    {
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string NameOfOrder { get; set; }
        public double SumOfOrder { get; set; }
        public string LastNameOfCustomer { get; set; }
    }
}
