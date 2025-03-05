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
        private void Save()
        {
            unitOfWork.save();
            
        }
        public List<StudentDto> GetAllStudent()
        {
            
            var students = StudentRepository.GetAll(includeProperties: s=>s.department);
            return mapper.Map<List<StudentDto>>(students);
        }
        public StudentDto GetById(int id)
        {
            var student = StudentRepository.GetById(id);
            if (student is null)
                throw new StudentNotFoundException(id);
            return mapper.Map<StudentDto>(student);
        
        }
        public void Add(StudentDtoForAdd studentDto)
        {
           
            var student = mapper.Map<Student>(studentDto);
            StudentRepository.Add(student);
            Save();
            
        }
        public void Update(StudentDtoForAdd studentDto)
        {
            var student = mapper.Map<Student>(studentDto);
            StudentRepository.Update(student);
            Save();
        }
        public void Delete(int id)
        {
            var student = StudentRepository.GetById(id);
            if (student is null)
                throw new StudentNotFoundException(id);
            StudentRepository.Delete(student);
            Save();
        }

        public List<StudentDtoForDepartment> GetAllByDepartment(int departmentid)
        {
            var students = StudentRepository.GetAll(s => s.DepartmentId == departmentid, s => s.department,s=>s.StudentCourses);
            return mapper.Map<List<StudentDtoForDepartment>>(students);
        }

        public List<StudentCourseDto> GetAllStudentsWithCourses()
        {
            var students = StudentRepository.GetAll(includeProperties:s=>s.department);
            return mapper.Map <List<StudentCourseDto>>(students);
        }
    }
}
