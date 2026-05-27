using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WMS.Application.DTOs;
using WMS.Application.Interfaces;
using WMS.Domain.Entities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly WMSDbContext _context;
        private readonly IMapper _mapper;

        public AttendanceService(WMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceDto>> GetAllAsync()
        {
            var list = await _context.Attendances
                .Include(a => a.Employee)
                .ToListAsync();

            return list.Select(a => new AttendanceDto
            {
                AttendanceId = a.AttendanceId,
                EmpId = a.EmpId,
                EmployeeName = a.Employee != null
                    ? a.Employee.FirstName + " " + a.Employee.LastName
                    : "Unknown",
                CheckIn = a.CheckIn,
                CheckOut = a.CheckOut,
                TotalHours = a.TotalHours,
                WorkMode = a.WorkMode,
                AttendanceDate = a.AttendanceDate
            });
        }

        public async Task<IEnumerable<AttendanceDto>> GetByEmployeeIdAsync(int empId)
        {
            var list = await _context.Attendances
                .Include(a => a.Employee)
                .Where(a => a.EmpId == empId)
                .ToListAsync();

            return list.Select(a => new AttendanceDto
            {
                AttendanceId = a.AttendanceId,
                EmpId = a.EmpId,
                EmployeeName = a.Employee != null
                    ? a.Employee.FirstName + " " + a.Employee.LastName
                    : "Unknown",
                CheckIn = a.CheckIn,
                CheckOut = a.CheckOut,
                TotalHours = a.TotalHours,
                WorkMode = a.WorkMode,
                AttendanceDate = a.AttendanceDate
            });
        }

        public async Task<AttendanceDto?> GetByIdAsync(int id)
        {
            var item = await _context.Attendances
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.AttendanceId == id);
            if (item == null) return null;
            return new AttendanceDto
            {
                AttendanceId = item.AttendanceId,
                EmpId = item.EmpId,
                EmployeeName = item.Employee != null
                    ? item.Employee.FirstName + " " + item.Employee.LastName
                    : "Unknown",
                CheckIn = item.CheckIn,
                CheckOut = item.CheckOut,
                TotalHours = item.TotalHours,
                WorkMode = item.WorkMode,
                AttendanceDate = item.AttendanceDate
            };
        }

        public async Task<AttendanceDto> CreateAsync(CreateAttendanceDto dto)
        {
            var item = _mapper.Map<Attendance>(dto);
            if (item.CheckOut.HasValue)
                item.TotalHours = (item.CheckOut.Value - item.CheckIn).TotalHours;
            _context.Attendances.Add(item);
            await _context.SaveChangesAsync();
            return new AttendanceDto
            {
                AttendanceId = item.AttendanceId,
                EmpId = item.EmpId,
                CheckIn = item.CheckIn,
                CheckOut = item.CheckOut,
                TotalHours = item.TotalHours,
                WorkMode = item.WorkMode,
                AttendanceDate = item.AttendanceDate
            };
        }

        public async Task<AttendanceDto?> UpdateAsync(int id, UpdateAttendanceDto dto)
        {
            var item = await _context.Attendances.FindAsync(id);
            if (item == null) return null;
            if (dto.CheckOut.HasValue)
            {
                item.CheckOut = dto.CheckOut;
                item.TotalHours = (dto.CheckOut.Value - item.CheckIn).TotalHours;
            }
            if (dto.WorkMode != null) item.WorkMode = dto.WorkMode;
            await _context.SaveChangesAsync();
            return new AttendanceDto
            {
                AttendanceId = item.AttendanceId,
                EmpId = item.EmpId,
                CheckIn = item.CheckIn,
                CheckOut = item.CheckOut,
                TotalHours = item.TotalHours,
                WorkMode = item.WorkMode,
                AttendanceDate = item.AttendanceDate
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Attendances.FindAsync(id);
            if (item == null) return false;
            _context.Attendances.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}