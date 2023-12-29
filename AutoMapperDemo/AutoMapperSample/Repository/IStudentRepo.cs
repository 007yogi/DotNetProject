using AutoMapperSample.Models;

namespace AutoMapperSample.Repository
{
    public interface IStudentRepo
    {
        Task<List<StudentDTO>> GetStudent();
        Task<string> Task1();
        Task<string> Task2();
        Task<string> Task3();
    }
}
