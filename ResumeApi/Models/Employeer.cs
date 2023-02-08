using System.Reflection.Metadata.Ecma335;

namespace ResumeApi.Models
{
    public class Employeer
    {
        public int EmployeerID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CompanySectorID { get; set; }
        public CompanySector CompanySector { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
        public int Activity { get; set; }

    }
}
