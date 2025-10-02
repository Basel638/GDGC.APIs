using GDGC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Infrastructure.Configurations
{
    internal class AssignmentSubmitionsConfigs : IEntityTypeConfiguration<AssignmentSubmitions>
    {
        public void Configure(EntityTypeBuilder<AssignmentSubmitions> builder)
        {
            builder.HasKey(AS => new { AS.StudentId, AS.AssignmentId});

            builder.HasOne(U => U.Student)
                   .WithMany()
                   .HasForeignKey(AS => AS.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(AS => AS.Assignment)
                .WithMany()
                .HasForeignKey(AS => AS.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
