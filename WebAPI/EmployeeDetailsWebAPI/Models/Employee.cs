using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeDetailsWebAPI.Models
{
    public class Employee
    {
        [BindNever]
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public long phonenumber { get; set; }
        public int salary { get; set; }
        public string department { get; set; }

    }
}
