using System.Text.RegularExpressions;
using Classwork_4_Application.DTOs;
using Classwork_4_Application.Interfaces;
using Classwork_4_Application.Interfaces.Repositories;
using Classwork_4_Domain.Entity;

namespace Classwork_4_Application.Services;

public class ReaderService : IReaderService
{
    private readonly IReaderRepository _readerRepository;

    public ReaderService(IReaderRepository readerRepository)
    {
        _readerRepository = readerRepository;
    }

    public async Task<List<ReadersDTO>> GetReadersAsync(GetReadersDTO filter)
    {
        var readers = await _readerRepository.GetReadersAsync();

        var query = readers.AsQueryable();

        if (filter.Status.HasValue)
            query = query.Where(r => (int)r.Status == filter.Status.Value);

        return query.Select(r => new ReadersDTO
        {
            Id = r.Id,
            FirstName = r.FirstName,
            LastName = r.LastName,
            PersonalNumber = r.PersonalNumber,
            Phone = r.Phone,
            Email = r.Email,
            RegistrationDate = r.RegistrationDate,
            Status = r.Status
        }).ToList();
    }

    public async Task<ReadersDTO?> GetReaderByIdAsync(int id)
    {
        var reader = await _readerRepository.GetReaderByIdAsync(id);

        if (reader == null)
            return null;

        return new ReadersDTO
        {
            Id = reader.Id,
            FirstName = reader.FirstName,
            LastName = reader.LastName,
            PersonalNumber = reader.PersonalNumber,
            Phone = reader.Phone,
            Email = reader.Email,
            RegistrationDate = reader.RegistrationDate,
            Status = reader.Status
        };
    }

    public async Task<string> AddReaderAsync(CreateReaderDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FirstName))
            return "First name is required.";

        if (string.IsNullOrWhiteSpace(dto.LastName))
            return "Last name is required.";

        if (string.IsNullOrWhiteSpace(dto.PersonalNumber))
            return "Personal number is required.";

        if (string.IsNullOrWhiteSpace(dto.Email))
            return "Email is required.";

        bool personalNumberExists =
            await _readerRepository.PersonalNumberExistsAsync(dto.PersonalNumber);

        if (personalNumberExists)
            return "Personal number must be unique.";

        if (!IsValidEmail(dto.Email))
            return "Email format is not valid.";

        var reader = new Reader
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PersonalNumber = dto.PersonalNumber,
            Phone = dto.Phone,
            Email = dto.Email,
            RegistrationDate = DateTime.Now,
            Status = ReaderStatus.Active
        };

        await _readerRepository.AddReaderAsync(reader);
        await _readerRepository.SaveChangesAsync();

        return "Reader added successfully.";
    }

    public async Task<string> UpdateReaderAsync(UpdateReaderDTO dto)
    {
        var existingReader =
            await _readerRepository.GetReaderByIdAsync(dto.Id);

        if (existingReader == null)
            return "Reader not found.";

        if (string.IsNullOrWhiteSpace(dto.FirstName))
            return "First name is required.";

        if (string.IsNullOrWhiteSpace(dto.LastName))
            return "Last name is required.";

        if (string.IsNullOrWhiteSpace(dto.PersonalNumber))
            return "Personal number is required.";

        if (string.IsNullOrWhiteSpace(dto.Email))
            return "Email is required.";

        bool personalNumberExists =
            await _readerRepository.PersonalNumberExistsAsync(dto.PersonalNumber, dto.Id);

        if (personalNumberExists)
            return "Personal number must be unique.";

        if (!IsValidEmail(dto.Email))
            return "Email format is not valid.";

        existingReader.FirstName = dto.FirstName;
        existingReader.LastName = dto.LastName;
        existingReader.PersonalNumber = dto.PersonalNumber;
        existingReader.Phone = dto.Phone;
        existingReader.Email = dto.Email;
        existingReader.Status = dto.Status;

        await _readerRepository.SaveChangesAsync();

        return "Reader updated successfully.";
    }

    public async Task<string> DeleteReaderAsync(int id)
    {
        var reader = await _readerRepository.GetReaderByIdAsync(id);

        if (reader == null)
            return "Reader not found.";

        bool hasLoans = await _readerRepository.HasLoansAsync(id);

        if (hasLoans)
            return "Cannot delete this reader because they have loan history.";

        _readerRepository.DeleteReader(reader);

        await _readerRepository.SaveChangesAsync();

        return "Reader deleted successfully.";
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}