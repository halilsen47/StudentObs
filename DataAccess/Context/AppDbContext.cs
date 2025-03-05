using DataAccess.Config;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<LectureDepartments> LectureDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CourseConfig());
            //modelBuilder.ApplyConfiguration(new DepartmentConfig());
            //modelBuilder.ApplyConfiguration(new LectureConfig());
            //modelBuilder.ApplyConfiguration(new LectureDepartmentConfig());
            //modelBuilder.ApplyConfiguration(new StudentConfig());
            //modelBuilder.ApplyConfiguration(new StudentCourseConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
