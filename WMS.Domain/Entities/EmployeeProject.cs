using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities
{
    public class EmployeeProject
    {
        [Key]
        public int AllocationId { get; set; }
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        public DateTime AssignedOn { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Employee? Employee { get; set; }
        public Project? Project { get; set; }
    }
}