using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs
{
    public class LeaveDto
    {
        public int LeaveId { get; set; }
        public int EmpId { get; set; }
        public string? EmployeeName { get; set; }
        public string LeaveType { get; set; } = string.Empty;
        public string? Reason { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime AppliedOn { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }

    public class CreateLeaveDto
    {
        [Required] public int EmpId { get; set; }
        [Required] public string LeaveType { get; set; } = string.Empty;
        public string? Reason { get; set; }
        [Required] public DateTime FromDate { get; set; }
        [Required] public DateTime ToDate { get; set; }
    }

    public class UpdateLeaveStatusDto
    {
        [Required] public string Status { get; set; } = string.Empty;
        public int? ApprovedBy { get; set; }
    }
}