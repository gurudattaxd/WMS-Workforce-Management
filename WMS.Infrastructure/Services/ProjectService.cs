using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WMS.Application.DTOs;
using WMS.Application.Interfaces;
using WMS.Domain.Entities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly WMSDbContext _context;
        private readonly IMapper _mapper;

        public ProjectService(WMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var list = await _context.Projects
                .Include(p => p.Client)
                .ToListAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(list);
        }

        public async Task<ProjectDto?> GetByIdAsync(int id)
        {
            var item = await _context.Projects
                .Include(p => p.Client)
                .FirstOrDefaultAsync(p => p.ProjectId == id);
            if (item == null) return null;
            return _mapper.Map<ProjectDto>(item);
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
        {
            var item = _mapper.Map<Project>(dto);
            item.Status = "Active";
            _context.Projects.Add(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(item);
        }

        public async Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto dto)
        {
            var item = await _context.Projects.FindAsync(id);
            if (item == null) return null;
            _mapper.Map(dto, item);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Projects.FindAsync(id);
            if (item == null) return false;
            _context.Projects.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EmployeeProjectDto>> GetEmployeesByProjectAsync(int projectId)
        {
            var list = await _context.EmployeeProjects
                .Include(ep => ep.Employee)
                .Include(ep => ep.Project)
                .Where(ep => ep.ProjectId == projectId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeProjectDto>>(list);
        }

        public async Task<EmployeeProjectDto> AssignEmployeeAsync(CreateEmployeeProjectDto dto)
        {
            var item = _mapper.Map<EmployeeProject>(dto);
            item.CreateDate = DateTime.Now;
            item.Status = true;
            _context.EmployeeProjects.Add(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeProjectDto>(item);
        }

        public async Task<bool> RemoveEmployeeAsync(int allocationId)
        {
            var item = await _context.EmployeeProjects.FindAsync(allocationId);
            if (item == null) return false;
            item.Status = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}