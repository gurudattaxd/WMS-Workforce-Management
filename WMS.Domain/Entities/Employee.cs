using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public char Gender { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public Department? Department { get; set; }
        public Role? Role { get; set; }
    }
}