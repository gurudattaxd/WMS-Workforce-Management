using WMS.Application.DTOs;

namespace WMS.Application.Interfaces
{
    public interface ILeaveService
    {
        Task<IEnumerable<LeaveDto>> GetAllAsync();
        Task<IEnumerable<LeaveDto>> GetByEmployeeIdAsync(int empId);
        Task<LeaveDto?> GetByIdAsync(int id);
        Task<LeaveDto> CreateAsync(CreateLeaveDto dto);
        Task<LeaveDto?> UpdateStatusAsync(int id, UpdateLeaveStatusDto dto);
        Task<bool> DeleteAsync(int id);
    }
}