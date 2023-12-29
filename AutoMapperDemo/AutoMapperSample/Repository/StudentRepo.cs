using AutoMapper;
using AutoMapperSample.EFData;
using AutoMapperSample.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperSample.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public StudentRepo(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<StudentDTO>> GetStudent()
        {
            var stdList = await _context.students.ToListAsync();
            return _mapper.Map<List<StudentDTO>>(stdList);
        }

        public async Task<string> Task1()
        {
            await Task.Delay(4000);
            return "Task1 Completed.";
        }
        public async Task<string> Task2()
        {
            await Task.Delay(2000);
            return "Task2 Completed.";
        }
        public async Task<string> Task3()
        {
            await Task.Delay(6000);
            return "Task3 Completed.";
        }
    }
}
