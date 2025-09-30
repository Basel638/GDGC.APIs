using GDGC.Domain.Entities._3___Relationships_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Infrastructure.Configurations
{
    internal class StudentTrackConfigs : IEntityTypeConfiguration<StudentTrack>
    {
        public void Configure(EntityTypeBuilder<StudentTrack> builder)
        {
            // Composite Primary Key (StudentId, trackId)
            builder.HasKey(st => new { st.StudentId, st.TrackId });

            // Student - StudentTracks (1 - M)
            builder.HasOne(st => st.Student)
                   .WithMany()
                   .HasForeignKey(st => st.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
            // Track - StudentTrack (1 - M)
            builder.HasOne(st => st.Track)
                     .WithMany()
                     .HasForeignKey(st => st.TrackId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
