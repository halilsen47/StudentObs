using AutoMapper;
using Entity.DataTransferObject;
using Entity.Entities;

namespace web.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<StudentDto, Student>();
            CreateMap<StudentDtoForAdd, Student>();
            CreateMap<Course, CourseDto>(); // Course -> CourseDto Mapping

            CreateMap<Student, StudentDto>()
                .ForMember(sdto => sdto.DepartmentName, opt => opt.MapFrom(src => src.department.DepartmentName))
                .ForMember(sdto => sdto.Courses, opt => opt.MapFrom(src => src.StudentCourses.Select(sc=>sc.Course)));
                

            CreateMap<Student, StudentCourseDto>()
            .ForMember(sdto => sdto.Courses, opt => opt.MapFrom(src => src.StudentCourses.Select(sc => sc.Course)))
            .ForMember(sdto=>sdto.departmentName , opt=>opt.MapFrom(src=>src.department.DepartmentName));

            CreateMap<Student,StudentDtoForDepartment>()
                .ForMember(sdto=>sdto.DepartmentName,opt=>opt.MapFrom(src=>src.department.DepartmentName));

            CreateMap<Student, StudentDtoForAdd>().ReverseMap();
        }
    }
}
