using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ChildAllergy
    {
        public Allergy Allergy { get; set; }
        public AllergySeverity Severity { get; set; }
    }

    public enum AllergySeverity
    {
        Mild = 1,
        Moderate = 2,
        Severe = 3
    }
}
