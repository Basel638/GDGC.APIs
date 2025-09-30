using GDGC.Domain.Entities._3___Relationships_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GDGC.Infrastructure.Configurations
{
    internal class StudentAttendSessionConfigs : IEntityTypeConfiguration<StudentAttendSession>
    {
        public void Configure(EntityTypeBuilder<StudentAttendSession> builder)
        {
            builder.HasKey(s => new { s.StudentId, s.SessionId });
            builder.HasOne(s => s.Student)
                   .WithMany()
                   .HasForeignKey(s => s.StudentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Session)
                     .WithMany()
                     .HasForeignKey(s => s.SessionId)
                     .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Topic)
                    .WithMany()
            .HasForeignKey(s => s.TopicId)
                    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
