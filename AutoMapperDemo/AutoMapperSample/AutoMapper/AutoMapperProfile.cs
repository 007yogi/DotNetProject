using AutoMapper;
using AutoMapperSample.Models;

namespace AutoMapperSample.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /*
             * Projection and Conditional Mapping.             
             */
            CreateMap<Student, StudentDTO>().ReverseMap() ;
        }
    }
}
