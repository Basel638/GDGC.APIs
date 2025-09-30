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
	public class ProjectAttemptionConfigs : IEntityTypeConfiguration<ProjectAttemption>
	{
		public void Configure(EntityTypeBuilder<ProjectAttemption> builder)
		{

			builder.HasKey(Attempt => new { Attempt.UserId, Attempt.ProjectId });

			builder.HasOne(U => U.User)
				   .WithMany()
				   .HasForeignKey(U => U.UserId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(E => E.Project)
				   .WithMany()
				   .HasForeignKey(E => E.ProjectId)
				   .OnDelete(DeleteBehavior.Cascade);


			builder.HasOne(T => T.Level)
				   .WithMany()
				   .HasForeignKey(T => T.LevelId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.Property(User => User.IsPassed)
				   .HasDefaultValue(false);

			builder.Property(User => User.IsHighstScore)
				   .HasDefaultValue(false);
		}
	}
}
