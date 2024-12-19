namespace LegalCaseManagementSystem.Models
{
    public class CourtCase
    {
        public int CaseID { get; set; }
        public string DefendantName { get; set; }
        public string CaseStatus { get; set; }
        public string Charge { get; set; }
        public DateTime CaseDate { get; set; }
        public int? ProxyNumber { get; set; }
        public DateTime? ProxyDate { get; set; }
        public int CourtID { get; set; }
        public int LawyerID { get; set; }
    }
}