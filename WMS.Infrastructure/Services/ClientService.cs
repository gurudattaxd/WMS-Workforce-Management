using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WMS.Application.DTOs;
using WMS.Application.Interfaces;
using WMS.Domain.Entities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly WMSDbContext _context;
        private readonly IMapper _mapper;

        public ClientService(WMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var list = await _context.Clients.ToListAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(list);
        }

        public async Task<ClientDto?> GetByIdAsync(int id)
        {
            var item = await _context.Clients.FindAsync(id);
            if (item == null) return null;
            return _mapper.Map<ClientDto>(item);
        }

        public async Task<ClientDto> CreateAsync(CreateClientDto dto)
        {
            var item = _mapper.Map<Client>(dto);
            item.Status = true;
            _context.Clients.Add(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClientDto>(item);
        }

        public async Task<ClientDto?> UpdateAsync(int id, UpdateClientDto dto)
        {
            var item = await _context.Clients.FindAsync(id);
            if (item == null) return null;
            _mapper.Map(dto, item);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClientDto>(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Clients.FindAsync(id);
            if (item == null) return false;
            _context.Clients.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}