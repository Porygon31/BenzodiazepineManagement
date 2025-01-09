using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenzodiazepineManagement.Models;

namespace BenzodiazepineManagement.Models
{
    public class Benzodiazepine
    {
        public int Id { get; set; }
        public string OfficialName { get; set; }
        public string MoleculeName { get; set; }
        public List<PharmacologicalProperty> PharmacologicalProperties { get; set; }
        public ValueRange HalfLife { get; set; }
        public ValueRange OnsetTime { get; set; }
        public ValueRange Bioavailability { get; set; }
        public string Metabolism { get; set; }
        public string Elimination { get; set; }
        public ValueRange ActionDurationHours { get; set; }
        public List<string> TherapeuticIndications { get; set; }
        public string Dosage { get; set; }
        public string ImagePath { get; set; }
        public string HalfLifeFormatted => HalfLife?.ToString() ?? string.Empty;
        public string OnsetTimeFormatted => OnsetTime?.ToString() ?? string.Empty;
        public string BioavailabilityFormatted => Bioavailability?.ToString() ?? string.Empty;
        public string ActionDurationFormatted => ActionDurationHours?.ToString() ?? string.Empty;

    }
}
