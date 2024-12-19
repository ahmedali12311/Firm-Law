namespace LegalCaseManagementSystem.Models
{
    public class LegalCourt
    {
        public int CourtID { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionDay { get; set; }
        public string Judge1FirstName { get; set; }
        public string Judge1MiddleName { get; set; }
        public string Judge1LastName { get; set; }
        public string Judge2FirstName { get; set; }
        public string Judge2MiddleName { get; set; }
        public string Judge2LastName { get; set; }
        public string Judge3FirstName { get; set; }
        public string Judge3MiddleName { get; set; }
        public string Judge3LastName { get; set; }
        public string ReserveJudgeFirstName { get; set; }
        public string ReserveJudgeMiddleName { get; set; }
        public string ReserveJudgeLastName { get; set; }
    }
}