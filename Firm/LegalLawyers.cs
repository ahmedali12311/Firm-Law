namespace LegalCaseManagementSystem.Models
{
    public class LegalLawyer
    {
        public int LawyerID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public int CaseCount { get; set; }
        public int CourtID { get; set; }
        public string PhoneNumber { get; set; }
    }
}
