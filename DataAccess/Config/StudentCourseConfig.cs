using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class StudentCourseConfig : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => sc.StudentCourseId);

            builder.HasOne(sc => sc.Student)
                  .WithMany(s => s.StudentCourses)  // Bir öğrenci birden fazla kurs alabilir
                  .HasForeignKey(sc => sc.StudentId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Foreign Key: CourseId
            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.StudentCourses)  // Bir kurs birden fazla öğrenciye ait olabilir
                   .HasForeignKey(sc => sc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new StudentCourse
                {
                    StudentCourseId = 1,
                    StudentId = 1,  // Ali Demir
                    CourseId = 1  // Mathematics 101
                },
                new StudentCourse
                {
                    StudentCourseId = 2,
                    StudentId = 1,  // Ali Demir
                    CourseId = 2  // Mathematics 101
                },
                new StudentCourse
                {
                    StudentCourseId = 3,
                    StudentId = 2,  // Ayşe Çelik
                    CourseId = 2  // Physics 101
                }
            );

        }
    }
}
