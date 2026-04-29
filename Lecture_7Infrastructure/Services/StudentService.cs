using Lecture_7Application.DTOs;
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
    }
}
