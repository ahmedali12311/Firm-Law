namespace LegalCaseManagementSystem.Models
{
    public class SystemUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public DateTime DateAdded { get; set; }
        public string Username { get; set; } 

    }
}