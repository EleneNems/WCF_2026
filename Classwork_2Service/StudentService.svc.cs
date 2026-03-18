using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace Classwork_2Service
{
    public class StudentService : IStudentService
    {
        string connectionString = ConfigurationManager
            .ConnectionStrings["StudentDBConnection"].ConnectionString;

        public List<Student> GetStudents()
        {
            List<Student> list = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Student
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Age = (int)dr["Age"]
                    });
                }
            }

            return list;
        }

        public void AddStudent(Student s)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Students VALUES (@fn,@ln,@age)", con);

                cmd.Parameters.AddWithValue("@fn", s.FirstName);
                cmd.Parameters.AddWithValue("@ln", s.LastName);
                cmd.Parameters.AddWithValue("@age", s.Age);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student s)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Students SET FirstName=@fn, LastName=@ln, Age=@age WHERE Id=@id", con);

                cmd.Parameters.AddWithValue("@fn", s.FirstName);
                cmd.Parameters.AddWithValue("@ln", s.LastName);
                cmd.Parameters.AddWithValue("@age", s.Age);
                cmd.Parameters.AddWithValue("@id", s.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Students WHERE Id=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}