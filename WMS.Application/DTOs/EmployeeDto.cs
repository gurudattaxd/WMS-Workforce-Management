using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public char Gender { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string Status { get; set; } = "Active";
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }

    public class CreateEmployeeDto
    {
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [Required][EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string PhoneNumber { get; set; } = string.Empty;
        [Required] public char Gender { get; set; }
        [Required] public DateTime DOB { get; set; }
        [Required] public DateTime DOJ { get; set; }
        [Required] public int DepartmentId { get; set; }
        [Required] public int RoleId { get; set; }
    }

    public class UpdateEmployeeDto
    {
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [Required] public string PhoneNumber { get; set; } = string.Empty;
        public char Gender { get; set; }
        public DateTime DOB { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; } = "Active";
    }
}