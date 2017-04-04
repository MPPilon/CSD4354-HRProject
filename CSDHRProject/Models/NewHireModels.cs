using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSDHRProject.Models
{
    public class NewHireModels
    {
        public String Name { get; set; }
        public String Id { get; set; }
        public String Sin { get; set; }
        public String BenefitNumber {get;set;}
        public int RateOfPay { get; set; }       
        public int VacationDays { get; set; }
        public int SickDays { get; set; }
        public String BenefitCertificateFileName { get; set; }
        public String TrainingCertificateFileName { get; set; }
    }
        public class NewHireEditViewModel
    {
        public HttpPostedFileBase BenefitFile { get; set; }
        public HttpPostedFileBase TrainingFile { get; set; }
    }
    
}