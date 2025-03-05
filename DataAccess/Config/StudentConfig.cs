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
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {


            builder.Property(s => s.FirstName)
               .IsRequired()  // FirstName alanı zorunlu
               .HasMaxLength(50);

            builder.Property(s => s.LastName)
               .IsRequired()  // LastName alanı zorunlu
               .HasMaxLength(50);

            builder.Property(s => s.PhoneNumber)
               .HasMaxLength(11);

            builder.Property(s => s.Email)
               .HasMaxLength(100)  // Email alanı için max uzunluk
               .IsRequired(false);

            builder.Property(s => s.Adress)
               .HasMaxLength(250)
               .IsRequired(false);

            builder.HasOne(s => s.department)
               .WithMany(d => d.Students)  // Department ile ilişki kuruyoruz
               .HasForeignKey(s => s.DepartmentId)
               .OnDelete(DeleteBehavior.SetNull);


            //one-to-many
            builder.HasOne(s => s.department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId);

            builder.HasData(
                new Student
                {
                    StudentId = 1,
                    FirstName = "Ali",
                    LastName = "Demir",
                    BirthDate = new DateTime(2000, 5, 10),
                    PhoneNumber = "5551234567",
                    Email = "ali.demir@email.com",
                    Adress = "Istanbul, Turkey",
                    DepartmentId = 1  // Computer Science department
                },
                new Student
                {
                    StudentId = 2,
                    FirstName = "Ayşe",
                    LastName = "Çelik",
                    BirthDate = new DateTime(2001, 8, 5),
                    PhoneNumber = "5559876543",
                    Email = "ayse.celik@email.com",
                    Adress = "Ankara, Turkey",
                    DepartmentId = 2  // Electrical Engineering department
                }
            );
        }
    }
}
