using Classwork_1.Contracts;
using Classwork_1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Classwork_1.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentService.svc or StudentService.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentService
    {
        AppDBContent _context = new AppDBContent();

        public void AddStudent(StudentDTO student)
        {
            if (student == null)

                throw new ArgumentNullException(nameof(student));

            Student studentEntity = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };
            _context.Students.Add(studentEntity);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                throw new Exception("Student Not Found");

            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(StudentDTO student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            var existingStudent = _context.Students.FirstOrDefault(x => x.Id == student.Id);

            if (existingStudent == null)
                throw new Exception("Student not found");

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;

            _context.SaveChanges();

        }


        public List<StudentDTO> GetAllStudents()
        {
            return _context.Students.Select(s => new StudentDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName
            }).ToList();

        }

        public StudentDTO GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return null;

            return new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }
    }
}
