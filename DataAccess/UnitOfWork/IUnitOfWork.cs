using DataAccess.Repository.Abstractions;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStudentRepository GetStudentRepository();
        void save();
    }
}
