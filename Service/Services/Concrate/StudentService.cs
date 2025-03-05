using AutoMapper;
using DataAccess.Context;
using DataAccess.Repository.Abstractions;
using DataAccess.Repository.Concrate;
using DataAccess.UnitOfWork;
using Entity.DataTransferObject;
using Entity.Entities;
using Entity.Exceptions;
using NLog;
using Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrate
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILoggerService logger;
        private IStudentRepository StudentRepository { get; set; }
        public StudentService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerService logger = null)
        {
            this.unitOfWork = unitOfWork;
            StudentRepository = unitOfWork.GetStudentRepository();
            this.mapper = mapper;
            this.logger = logger;
        }
        private async Task Save()
        {
            await unitOfWork.saveAsync();
            
        }
        public async Task<List<StudentDto>> GetAllStudentAsync()
        {
            
            var students = await StudentRepository.GetAllAsync(includeProperties: s=>s.department);
            return mapper.Map<List<StudentDto>>(students);
        }
        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await StudentRepository.GetByIdAsync(id);
            if (student is null)
                throw new StudentNotFoundException(id);
            return mapper.Map<StudentDto>(student);
        
        }
        public async Task AddAsync(StudentDtoForAdd studentDto)
        {
           
            var student = mapper.Map<Student>(studentDto);
            StudentRepository.Add(student);
            await Save();
            
        }
        public async Task UpdateAsync(StudentDtoForAdd studentDto)
        {
            var student = mapper.Map<Student>(studentDto);
            StudentRepository.Update(student);
            await Save();
        }
        public async Task DeleteAsync(int id)
        {
            var student = await StudentRepository.GetByIdAsync(id);
            if (student is null)
                throw new StudentNotFoundException(id);
            StudentRepository.Delete(student);
            await Save();
        }

        public async Task<List<StudentDtoForDepartment>> GetAllByDepartmentAsync(int departmentid)
        {
            var students = await StudentRepository.GetAllAsync(s => s.DepartmentId == departmentid, s => s.department,s=>s.StudentCourses);
            return mapper.Map<List<StudentDtoForDepartment>>(students);
        }

        public async Task<List<StudentCourseDto>> GetAllStudentsWithCoursesAsync()
        {
            var students = await StudentRepository.GetAllAsync(includeProperties:s=>s.department);
            return mapper.Map <List<StudentCourseDto>>(students);
        }
    }
}
