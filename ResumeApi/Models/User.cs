using System.Reflection.Metadata.Ecma335;

namespace ResumeApi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstInformation { get; set; }
        public int Activity { get; set; }
    }
}
