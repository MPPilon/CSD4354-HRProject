using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSDHRProject.Models
{
    public class EmployeeClaim
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual Address Address { get; set; }
        public Double Amount { get; set; }
        public DateTime Date { get; set; }
        public String Service { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
    public String Street { get; set; }
    public String City { get; set; }
    public String Provence { get; set; }
    public String Postal { get; set; }
    }
}