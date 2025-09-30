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
	public class ExamAttemptionConfigs : IEntityTypeConfiguration<ExamAttemption>
	{
		public void Configure(EntityTypeBuilder<ExamAttemption> builder)
		{
			// Composite Primary Key
				// why UserId with ExamId not TopicId ?
					// UserId and ExamId together succeded principles in PK => Ahmed Can't have more than on Exam for the same Exam Id

			builder.HasKey(Attempt => new { Attempt.UserId, Attempt.ExamId });

			builder.HasOne(U => U.User)
				   .WithMany()
				   .HasForeignKey(U => U.UserId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(E => E.Exam)
				   .WithMany()
				   .HasForeignKey(E => E.ExamId)
				   .OnDelete(DeleteBehavior.Cascade);


			builder.HasOne(T => T.Topic)
				   .WithMany()
				   .HasForeignKey(T => T.TopicId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.Property(User => User.IsPassed)
				   .HasDefaultValue(false);

			builder.Property(User => User.IsHighstScore)
				   .HasDefaultValue(false);
		}
	}
}
