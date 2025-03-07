using DataAccess.Context;
using DataAccess.Repository.Abstractions;
using Entity.Entities;
using Entity.RequestFeature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Concrate
{
    public class StudentRepository : RepositoryBase<Student> , IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context):base(context) 
        {
            _context = context;
        }

        //public List<Student> GetStudentsWithCourses(params Expression<Func<Student,object>>[] includesincludeProperties)
        //{

        //    IQueryable<Student> query = _context.Students;
        //    if (includesincludeProperties.Any())
        //    {
        //        foreach(var item in includesincludeProperties)
        //        {
        //            query = query.Include(item);
        //        }
        //    }
            
        //    return query
        //        .Include(s => s.StudentCourses)
        //        .ThenInclude(sc => sc.Course) // Çoka-çok ilişkide ThenInclude ekledik
        //        .ToList();
        //}

        public override PagedList<Student> GetAll(BookParameters bookParameters,Expression<Func<Student, bool>> predicate = null, params Expression<Func<Student, object>>[] includeProperties)
        {
            IQueryable<Student> query = _context.Students;
            if (predicate != null)
                query = query.Where(predicate);

            if (includeProperties.Any())
            {
                foreach (var properties in includeProperties)
                {
                    query = query.Include(properties);
                }
            }
            
            query = query.Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course);
             


            
            return PagedList<Student>.ToPagedList(query.ToList(),bookParameters.pageNumber,bookParameters.PageSize);
        }

        public override Student GetById(int id)
        {
            var student = _context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefault(s => s.StudentId.Equals(id));
            return student;
        }
    }
}
