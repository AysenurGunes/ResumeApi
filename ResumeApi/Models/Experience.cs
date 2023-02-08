namespace ResumeApi.Models
{
    public class Experience
    {
        public int ExperienceID { get; set; }
        public int EmployeeTitleID { get; set; }
        public EmployeeTitle EmployeeTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool StillWork { get; set; }
        public int CompanySectorID { get; set; }
        public CompanySector CompanySector { get; set; }
        //Fulltime-1
        //PartTime-2
        public int WorkType { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
        public int Activity { get; set; }
    }
}
