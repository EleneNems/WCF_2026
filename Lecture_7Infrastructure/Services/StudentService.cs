using Lecture_7Application.DTOs;
using Lecture_7Domain.Entity;
using Lecture_7Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_7Application.Services
{
    public class StudentService : IStudentServices
    {
        private readonly AppDBContext _context;

        public StudentService(AppDBContext context)
        {
            _context = context; 
        }

        public async Task<List<StudentsDTO>> GetStudents()
        {
            return await _context.Students.Select(s => new StudentsDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Age = s.Age,
            }).ToListAsync();
        }

        public async Task<StudentsDTO?> GetStudentById(int id)
        {
            return await _context.Students
                .Where(s => s.Id == id)
                .Select(s => new StudentsDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<StudentsDTO> AddStudent(CreateStudentDTO dto)
        {
            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return new StudentsDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age
            };
        }

        public async Task<StudentsDTO?> UpdateStudent(int id, CreateStudentDTO dto)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                return null;
            }

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Age = dto.Age;

            await _context.SaveChangesAsync();

            return new StudentsDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age
            };
        }

        public async Task<StudentsDTO?> DeleteStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                return null;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return new StudentsDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age
            };
        }
    }
}
