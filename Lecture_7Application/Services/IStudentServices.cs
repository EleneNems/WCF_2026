using Lecture_7Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_7Application.Services
{
    public interface IStudentServices
    {
        Task<List<StudentsDTO>> GetStudents();
        Task<StudentsDTO> GetStudentById(int id);
        Task<StudentsDTO> AddStudent(CreateStudentDTO dto);
        Task<StudentsDTO?> UpdateStudent(int id, CreateStudentDTO dto);
        Task<StudentsDTO?> DeleteStudent(int id);
    }
}
