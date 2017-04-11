using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSDHRProject.Models
{
    public class Project
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public  DateTime Date { get; set; }
        public String Description { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ApplicationUser Lead { get; set; }
    }

    public class ProjectUser
    {
        public int Id { get; set; }
        public virtual ApplicationUser User{ get; set; }
        public virtual Project Project { get; set; }
        

    }
}