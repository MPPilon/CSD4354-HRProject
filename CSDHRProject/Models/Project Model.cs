using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSDHRProject.Models
{
    public class Project_Model
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public  DateTime Date { get; set; }
        public String Author { get; set; }
        public String Lead { get; set; }



    }

    public class Project_user
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public bool Manager { get; set; }

    }
}