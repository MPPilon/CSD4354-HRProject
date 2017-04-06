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

    public class BenefitRegistration
    {
        public int Id { get; set; }
        public Boolean Single { get; set; }
        public Boolean Family { get; set; }
        public Boolean Standard { get; set; }
        public Boolean Extended { get; set; }
        public Boolean Dental { get; set; }
        public Boolean DentalNone { get; set; }
        public Boolean Optical { get; set; }
        public Boolean OpticalNone { get; set; }
        public Boolean Paramedical { get; set; }
        public Boolean ParamedicalNone { get; set; }
    }
}