namespace ResumeApi.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public int Activity { get; set; }
    }
}
