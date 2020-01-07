using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomConnect.Api.ViewModels
{
    public class ChildAllergyViewModel
    {
        public AllergyViewModel Allergy { get; set; }
        public AllergySeverity Severity { get; set; }
    }

    public enum AllergySeverity
    {
        Mild = 1,
        Moderate = 2,
        Severe = 3
    }
}
