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
	public class TopicConfigs : IEntityTypeConfiguration<Topic>
	{
		public void Configure(EntityTypeBuilder<Topic> builder)
		{
			builder.HasOne(T => T.Level)
				.WithMany()
				.HasForeignKey(T => T.LevelId)
				.OnDelete(DeleteBehavior.Cascade);

			
		}
	}
}
