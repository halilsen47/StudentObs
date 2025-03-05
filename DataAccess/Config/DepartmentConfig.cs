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
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepartmentId);

            builder.Property(d => d.DepartmentName)
                   .IsRequired()  // Zorunlu
                   .HasMaxLength(100);  // Max 100 karakter

            builder.HasMany(d => d.Students)
                   .WithOne(s => s.department)  // Öğrencinin bir departmanı olabilir
                   .HasForeignKey(s => s.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(d => d.LectureDepartments)
                  .WithOne(ld => ld.Department)  // Her LectureDepartment bir Departman'a ait
                  .HasForeignKey(ld => ld.DepartmentId)
                  .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Computer Science"
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Electrical Engineering"
                }
            );
        }
    }
}
