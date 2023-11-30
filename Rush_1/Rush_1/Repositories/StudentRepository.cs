using Dapper;
using Rush_1.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Rush_1.Repositories
{
    public class StudentRepository
    {
        private readonly IDbConnection _dbConnection;
        public StudentRepository()
        {
            string connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=School;User Id=sa;Password=3040;TrustServerCertificate=true;";
            _dbConnection = new SqlConnection(connectionString);
        }
        public void InsertStudent(Student student )
        {
            try
            {
                string sql = "INSERT INTO Student (Name, Email, Gender, CreationDate) VALUES (@Name, @Email, @Gender, @CreationDate);";
                _dbConnection.Execute(sql, student);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public Student GetStudentById(int studentId)
        {
            string sql = "SELECT * FROM Student WHERE StudentId = @StudentId;";
            return _dbConnection.QuerySingleOrDefault<Student>(sql, new { StudentId = studentId });
        }
        public void UpdateStudent(Student student)
        {
            string sql = "UPDATE Student SET Name = @Name, Email = @Email, Gender = @Gender, CreationDate = @CreationDate WHERE StudentId = @StudentId;";
            _dbConnection.Execute(sql, student);
        }
        public void DeleteStudent(int studentId)
        {
            string sql = "DELETE FROM Student WHERE StudentId = @StudentId;";
            _dbConnection.Execute(sql, new { StudentId = studentId });
        }
    }
}
