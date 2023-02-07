namespace ResumeApi.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string? WebPage { get; set; }
        public int Salary { get; set; }
         
    }
}
