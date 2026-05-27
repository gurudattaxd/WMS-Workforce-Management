using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WMS.Application.DTOs;
using WMS.Application.Interfaces;
using WMS.Domain.Entities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly WMSDbContext _context;
        private readonly IMapper _mapper;

        public LeaveService(WMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeaveDto>> GetAllAsync()
        {
            var list = await _context.Leaves
                .Include(l => l.Employee)
                .ToListAsync();
            return _mapper.Map<IEnumerable<LeaveDto>>(list);
        }

        public async Task<IEnumerable<LeaveDto>> GetByEmployeeIdAsync(int empId)
        {
            var list = await _context.Leaves
                .Include(l => l.Employee)
                .Where(l => l.EmpId == empId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<LeaveDto>>(list);
        }

        public async Task<LeaveDto?> GetByIdAsync(int id)
        {
            var item = await _context.Leaves
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.LeaveId == id);
            if (item == null) return null;
            return _mapper.Map<LeaveDto>(item);
        }

        public async Task<LeaveDto> CreateAsync(CreateLeaveDto dto)
        {
            var item = _mapper.Map<Leave>(dto);
            item.Status = "Pending";
            item.AppliedOn = DateTime.Now;
            _context.Leaves.Add(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<LeaveDto>(item);
        }

        public async Task<LeaveDto?> UpdateStatusAsync(int id, UpdateLeaveStatusDto dto)
        {
            var item = await _context.Leaves.FindAsync(id);
            if (item == null) return null;
            item.Status = dto.Status;
            item.ApprovedBy = dto.ApprovedBy;
            item.ApprovedOn = DateTime.Now;
            await _context.SaveChangesAsync();
            return _mapper.Map<LeaveDto>(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Leaves.FindAsync(id);
            if (item == null) return false;
            _context.Leaves.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}