using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSDHRProject.Models
{
    public class JobPosting
    {

        public int JobPostingId { get; set; }
        public String JobTitle { get; set; }
        public DateTime JobPostingDeadline { get; set; }
        public String JobDepartmentName { get; set; }

        //part for job posting view

       
        public String JobPostingFileName { get; set; }


    }

    public class JobApplication
    {
        public int JobApplicationId { get; set; }
        public String ApplicantFirstName { get; set; }
        public String ApplicantLastName { get; set; }
        public String ApplicantEmail { get; set; }
        public String ResumeFileName { get; set; }
        public String CoverLetterFileName { get; set; }

      
        //part for hr/manager 

        public String ApplicantStatus { get; set; }
        public virtual JobPosting JobPost { get; set; }
    }

    public class JobEditViewModel
    {
        public JobPosting Item { get; set; }
        public HttpPostedFileBase JobPostFile { get; set; }
    }

    public class ApplicationEditViewModel
    {
        public JobApplication Item { get; set; }
        public HttpPostedFileBase ResumeFile { get; set; }

        public HttpPostedFileBase CoverLetterFile { get; set; }
    }
}