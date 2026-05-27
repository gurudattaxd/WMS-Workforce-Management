using WMS.Application.DTOs;

namespace WMS.Application.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDto>> GetAllAsync();
        Task<IEnumerable<AttendanceDto>> GetByEmployeeIdAsync(int empId);
        Task<AttendanceDto?> GetByIdAsync(int id);
        Task<AttendanceDto> CreateAsync(CreateAttendanceDto dto);
        Task<AttendanceDto?> UpdateAsync(int id, UpdateAttendanceDto dto);
        Task<bool> DeleteAsync(int id);
    }
}