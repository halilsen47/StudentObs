using Entity.DataTransferObject;
using Entity.Entities;
using Entity.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Abstractions
{
    public interface IStudentService 
    {
        (List<StudentDto> students,MetaData metaData) GetAllStudent (BookParameters bookParameters);
        (List<StudentDtoForDepartment> students,MetaData metaData) GetAllByDepartment(BookParameters bookParameters,int id);
        (List<StudentCourseDto> students, MetaData metaData) GetAllStudentsWithCourses(BookParameters bookParameters);
        StudentDto GetById(int id);
        void Add(StudentDtoForAdd studentDto);
        void Delete(int id);
        void Update(StudentDtoForAdd studentDto);

    }
}
