using DataAccess.Context;
using DataAccess.Repository.Abstractions;
using DataAccess.Repository.Concrate;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWorks(AppDbContext context)
        {
            this.context = context;
        }

        public IStudentRepository GetStudentRepository()
        {
            return new StudentRepository(context);
        }

        public void save()
        {
            context.SaveChanges();
        }

       
    }
}
