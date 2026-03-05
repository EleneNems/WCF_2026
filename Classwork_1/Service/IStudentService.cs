using Classwork_1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Classwork_1.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        List<StudentDTO> GetAllStudents();

        [OperationContract]
        StudentDTO GetStudentById(int id);

        [OperationContract]
        void AddStudent(StudentDTO student);

        [OperationContract]
        void DeleteStudent(int id);

        [OperationContract]
        void UpdateStudent(StudentDTO student);

    }
}
