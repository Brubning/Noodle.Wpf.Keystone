using System;
using System.Collections.Generic;

namespace Noodle.Wpf.Keystone.Models
{
    public class Asset
    {
        public string Uprn { get; set; }
        public int AssetId { get; set; }
        public AssetStatus Status { get; set; }
        public string NlpgUprn { get; set; }
        public string ManagementGroup { get; set; }
        public string AssetType { get; set; }
        public string ParentUprn { get; set; }
        public string HouseName { get; set; }
        public string Block { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostCode { get; set; }
        public string OsLocation { get; set; }
        public string LastSurveyor { get; set; }
        public DateTime? LastSurveyDate { get; set; }
        public DateTime? NextSurveyDate { get; set; }
        public string Owner { get; set; }
        public DateTime? OwnerChangedDate { get; set; }
        public double OwnershipPercentage { get; set; }
        public double MarketValue { get; set; }
        public double AnnualRent { get; set; }
        public double AnnualOverheads { get; set; }
        public string Prn { get; set; }
        public string BaseAnalysisType { get; set; }
        public string XLocation { get; set; }
        public string YLocation { get; set; }
        public List<AnalysisClass> AnalysisClasses { get; set; }
    }

    public enum AssetStatus
    {
        Unsurveyed,
        Surveyed,
        Copied,
        SurveyedSelfRepresenting
    }

    public class AnalysisClass
    {
        public string ClassName { get; set; }
        public string TypeValue { get; set; }
    }
}
