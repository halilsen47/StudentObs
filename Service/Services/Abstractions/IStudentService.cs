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
        Task<List<StudentDto>> GetAllStudentAsync();
        Task<List<StudentDtoForDepartment>> GetAllByDepartmentAsync(int id);
        Task<List<StudentCourseDto>> GetAllStudentsWithCoursesAsync();
        Task<StudentDto> GetByIdAsync(int id);
        Task AddAsync(StudentDtoForAdd studentDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(StudentDtoForAdd studentDto);

    }
}
