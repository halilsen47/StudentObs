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
    public class LectureDepartmentConfig : IEntityTypeConfiguration<LectureDepartments>
    {
        public void Configure(EntityTypeBuilder<LectureDepartments> builder)
        {
            builder.HasKey(x => x.LectureDepartmentId);

            builder.HasOne(x => x.Lecture)
               .WithMany(l => l.LectureDepartments)
               .HasForeignKey(x => x.LectureId)  // Foreign key for Lecture
               .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Department)
              .WithMany(d => d.LectureDepartments)
              .HasForeignKey(x => x.DepartmentId)  // Foreign key for Department
              .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                new LectureDepartments
                {
                    LectureDepartmentId = 1,
                    LectureId = 1,  // Ahmet Yılmaz
                    DepartmentId = 1  // Computer Science department
                },
                new LectureDepartments
                {
                    LectureDepartmentId = 2,
                    LectureId = 2,  // Mehmet Kara
                    DepartmentId = 2  // Electrical Engineering department
                }
            );


        }
    }
}
