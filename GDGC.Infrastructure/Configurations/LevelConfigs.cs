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
	public class LevelConfigs : IEntityTypeConfiguration<Level>
	{
		public void Configure(EntityTypeBuilder<Level> builder)
		{
			builder.HasOne(L => L.Track)
					.WithMany()
					.HasForeignKey(L => L.TrackId)
					.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
