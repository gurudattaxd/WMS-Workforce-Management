using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Active";
        public int? ClientId { get; set; }
        public string? ClientName { get; set; }
    }

    public class CreateProjectDto
    {
        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ClientId { get; set; }
    }

    public class UpdateProjectDto
    {
        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Active";
        public int? ClientId { get; set; }
    }

    public class EmployeeProjectDto
    {
        public int AllocationId { get; set; }
        public int EmpId { get; set; }
        public string? EmployeeName { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime AssignedOn { get; set; }
        public bool Status { get; set; }
    }

    public class CreateEmployeeProjectDto
    {
        [Required] public int EmpId { get; set; }
        [Required] public int ProjectId { get; set; }
        [Required] public DateTime AssignedOn { get; set; }
        [Required] public string CreatedBy { get; set; } = string.Empty;
    }
}