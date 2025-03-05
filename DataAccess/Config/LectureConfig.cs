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
    public class LectureConfig : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.HasKey(l => l.LectureId);

            builder.Property(l => l.FirstName)
                   .IsRequired()  // Zorunlu
                   .HasMaxLength(50);

            builder.Property(l => l.LastName)
                   .IsRequired()  // Zorunlu
                   .HasMaxLength(50);

            builder.Property(l => l.BirthDate)
                  .IsRequired();

            builder.HasMany(l => l.Courses)
                  .WithOne(c => c.Lecture)  // Her dersin bir hocası vardır
                  .HasForeignKey(c => c.LectureId)
                  .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(l => l.LectureDepartments)
                  .WithOne(ld => ld.Lecture)
                  .HasForeignKey(ld => ld.LectureId)
                  .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                new Lecture
                {
                    LectureId = 1,
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    BirthDate = new DateTime(1985, 6, 15)
                },
                new Lecture
                {
                    LectureId = 2,
                    FirstName = "Mehmet",
                    LastName = "Kara",
                    BirthDate = new DateTime(1978, 3, 20)
                }
            );
        }
    }
}
