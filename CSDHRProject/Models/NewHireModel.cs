using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CSDHRProject.Models
{
    public class NewHireModel
    {
        public String Name { get; set; }
        public String Id { get; set; }
        public String Sin { get; set; }
        public String BenefitNumber { get; set; }
        public double RateOfPay { get; set; }

        [DisplayName("Vacation Days")]
        public int VacationDays { get; set; }
        public int SickDays { get; set; }
        public String BenefitCertificateFileName { get; set; }
        public String TrainingCertificateFileName { get; set; }
    }
    
    public class NewHireEditViewModel
    {
        public NewHireModel NewHire { get; set; }
        public HttpPostedFileBase BenefitFile { get; set; }
        public HttpPostedFileBase TrainingFile { get; set; }
    }
}
