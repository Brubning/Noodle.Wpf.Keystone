using System;

namespace Noodle.Wpf.Keystone.Models
{
    public class Visit
    {
        /* Fields used in the POST */
        public string Uprn{ get; set; }
        public string ServiceType { get; set; }
        public string Organisation { get; set; }
        public DateTime? Due { get; set; }
        public DateTime? Actual { get; set; }
        public DateTime? Next { get; set; }
        public string Outcome { get; set; }
        public string Comments { get; set; }

        /* Returned fields after creating the visit */
        public int VisitId { get; set; }
        public int AssetId { get; set; }
        public int ServiceTypeId { get; set; }
        public int OrganisationId { get; set; }
        public int OutcomeId { get; set; }
    }
}
