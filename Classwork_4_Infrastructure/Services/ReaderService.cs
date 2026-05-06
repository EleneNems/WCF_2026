using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classwork_4_Domain.Entity;
using Classwork_4_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Classwork_4_Infrastructure.Services;

public class ReaderService
{
    private readonly LibraryDbContext _context;

    public ReaderService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reader>> GetReadersAsync(ReaderStatus? status)
    {
        var query = _context.Readers.AsQueryable();

        if (status != null)
            query = query.Where(r => r.Status == status);

        return await query.ToListAsync();
    }

    public async Task<Reader?> GetReaderByIdAsync(int id)
    {
        return await _context.Readers.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<string> AddReaderAsync(Reader reader)
    {
        bool personalNumberExists = await _context.Readers
            .AnyAsync(r => r.PersonalNumber == reader.PersonalNumber);

        if (personalNumberExists)
            return "Personal number must be unique.";

        if (!IsValidEmail(reader.Email))
            return "Email format is not valid.";

        reader.RegistrationDate = DateTime.Now;
        reader.Status = ReaderStatus.Active;

        _context.Readers.Add(reader);
        await _context.SaveChangesAsync();

        return "Reader added successfully.";
    }

    public async Task<string> UpdateReaderAsync(Reader reader)
    {
        var existingReader = await _context.Readers.FindAsync(reader.Id);

        if (existingReader == null)
        {
            return "Reader not found.";
        }
            

        bool personalNumberExists = await _context.Readers.AnyAsync(r => r.PersonalNumber == reader.PersonalNumber && r.Id != reader.Id);

        if (personalNumberExists)
        {
            return "Personal number must be unique.";
        }
            

        if (!IsValidEmail(reader.Email))
        {
            return "Email format is not valid.";
        }
            

        existingReader.FirstName = reader.FirstName;
        existingReader.LastName = reader.LastName;
        existingReader.PersonalNumber = reader.PersonalNumber;
        existingReader.Phone = reader.Phone;
        existingReader.Email = reader.Email;
        existingReader.Status = reader.Status;

        await _context.SaveChangesAsync();

        return "Reader updated successfully.";
    }

    public async Task<string> DeleteReaderAsync(int id)
    {
        var reader = await _context.Readers.FindAsync(id);

        if (reader == null)
        {
            return "Reader not found.";
        }
            

        _context.Readers.Remove(reader);
        await _context.SaveChangesAsync();

        return "Reader deleted successfully.";
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}
