using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Active";
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public ICollection<EmployeeProject>? EmployeeProjects { get; set; }
    }
}