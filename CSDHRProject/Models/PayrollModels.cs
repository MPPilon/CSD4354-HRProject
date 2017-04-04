using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSDHRProject.Models
{
    public class PayrollModels
    {
        public int EmployeeId { get; set; }
        public String EmployeeName { get; set; }
        public int ManagerId { get; set; }
        public String ManagerName { get; set; }
        public double PayRate { get; set; }

    }
}