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
	public class StudentSessionsPerTrackConfigs : IEntityTypeConfiguration<StudentSessionsPerTrack>
	{
		public void Configure(EntityTypeBuilder<StudentSessionsPerTrack> builder)
		{
			
			builder.HasKey(Attempt => new { Attempt.UserId, Attempt.SessionId });

			builder.HasOne(U => U.User)
				   .WithMany()
				   .HasForeignKey(U => U.UserId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(E => E.Session)
				   .WithMany()
				   .HasForeignKey(E => E.SessionId)
				   .OnDelete(DeleteBehavior.Cascade);


			builder.HasOne(T => T.Track)
				   .WithMany()
				   .HasForeignKey(T => T.TrackId)
				   .OnDelete(DeleteBehavior.Cascade);

			
		}
	}
}
