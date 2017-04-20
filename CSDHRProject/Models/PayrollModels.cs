using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSDHRProject.Models
{
    public class PayrollModels
    {
        public int Id { get; set; }

        [Display(Name="Name")]
        public String Name { get; set; }

        public int ManagerId { get; set; }

        [Display(Name="Manager Name")]
        public String ManagerName { get; set; }

        [Display(Name="Pay Rate")]
        public double PayRate { get; set; }

        public String Position { get; set; }

        public int Project { get; set; }

        [Display(Name="Hours Worked")]
        public int HoursWorked { get; set; }

        [Display(Name="Project Name")]
        public String ProjectName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name="Date of Work")]
        public DateTime? TimesheetDate { get; set; }
    }
}