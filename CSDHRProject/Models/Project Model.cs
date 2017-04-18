using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSDHRProject.Models
{
    public class Project_Model
    {
        public int  Id { get; set;}
        public DateTime Date { get; set; }
        public String Name { get; set; }
       

        public class projectusers
        {
            public int Id { get; set; }
            public String lead { get; set; }
            public bool manager { get; set; }
        }


    }
}