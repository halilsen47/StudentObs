using DataAccess.Repository.Concrate;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Abstractions
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        //public List<Student> GetStudentsWithCourses(params Expression<Func<Student, object>>[] includesincludeProperties);

    }
}
