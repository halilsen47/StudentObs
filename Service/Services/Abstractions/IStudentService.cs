using Entity.DataTransferObject;
using Entity.Entities;
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
        List<StudentDto> GetAllStudent();
        List<StudentDtoForDepartment> GetAllByDepartment(int id);
        List<StudentCourseDto> GetAllStudentsWithCourses();
        StudentDto GetById(int id);
        void Add(StudentDtoForAdd studentDto);
        void Delete(int id);
        void Update(StudentDtoForAdd studentDto);

    }
}
