using WMS.Application.DTOs;

namespace WMS.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync();
        Task<ProjectDto?> GetByIdAsync(int id);
        Task<ProjectDto> CreateAsync(CreateProjectDto dto);
        Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<EmployeeProjectDto>> GetEmployeesByProjectAsync(int projectId);
        Task<EmployeeProjectDto> AssignEmployeeAsync(CreateEmployeeProjectDto dto);
        Task<bool> RemoveEmployeeAsync(int allocationId);
    }
}