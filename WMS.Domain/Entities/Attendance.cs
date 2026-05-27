using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Domain.Entities
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public int EmpId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public double? TotalHours { get; set; }
        public string? WorkMode { get; set; }
        public DateTime AttendanceDate { get; set; }

        [ForeignKey("EmpId")]
        public Employee? Employee { get; set; }
    }
}