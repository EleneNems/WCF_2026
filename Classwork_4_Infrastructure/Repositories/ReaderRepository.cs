using Classwork_4_Application.Interfaces.Repositories;
using Classwork_4_Domain.Entity;
using Classwork_4_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Infrastructure.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryDbContext _context;

        public ReaderRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reader>> GetReadersAsync()
        {
            return await _context.Readers.ToListAsync();
        }

        public async Task<Reader?> GetReaderByIdAsync(int id)
        {
            return await _context.Readers
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> PersonalNumberExistsAsync(string personalNumber, int? currentReaderId = null)
        {
            return await _context.Readers
                .AnyAsync(r => r.PersonalNumber == personalNumber &&
                               r.Id != currentReaderId);
        }

        public async Task<bool> HasLoansAsync(int readerId)
        {
            return await _context.Loans
                .AnyAsync(l => l.ReaderId == readerId);
        }

        public async Task AddReaderAsync(Reader reader)
        {
            await _context.Readers.AddAsync(reader);
        }

        public void DeleteReader(Reader reader)
        {
            _context.Readers.Remove(reader);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
