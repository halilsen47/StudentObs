using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.CourseName)
                   .IsRequired()  // Zorunlu
                   .HasMaxLength(100);

            builder.Property(c => c.AKTS)
                   .IsRequired()  // Zorunlu
                   .HasColumnType("int");

            builder.Property(c => c.Credit)
                   .IsRequired()  // Zorunlu
                   .HasColumnType("int");

            builder.HasOne(c => c.Lecture)
                   .WithMany(l => l.Courses)
                   .HasForeignKey(c => c.LectureId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.StudentCourses)
                   .WithOne(sc => sc.Course)
                   .HasForeignKey(sc => sc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                   new Course
                   {
                       CourseId = 1,
                       CourseName = "Mathematics 101",
                       AKTS = 6,
                       Credit = 3,
                       LectureId = 1
                   },
                   new Course
                   {
                       CourseId = 2,
                       CourseName = "Physics 101",
                       AKTS = 6,
                       Credit = 3,
                       LectureId = 2
                   }
            );
        }
    }
}
