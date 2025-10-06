using GDGC.Domain.Entities;
using GDGC.Domain.Entities._3___Relationships_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GDGC.Infrastructure
{
	public class GdgContext : DbContext
	{
		private readonly string _schema;

		public GdgContext(DbContextOptions<GdgContext> options) : base(options)
		{
			_schema = "dbo";

		}

		public GdgContext(DbContextOptions<GdgContext> options, string schema):base(options) 
        {
			_schema = schema ?? "dbo";
		}


		public DbSet<User> Users { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<ExamAttemption> ExamAttemptions { get; set; }
        public DbSet<ProjectAttemption> ProjectAttemptions { get; set; }
        public DbSet<StudentSessionsPerTrack> StudentSessionsPerTrack { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentSubmitions> AssignmentSubmitions { get; set; }
        public DbSet<StudentTrack> StudentTracks{ get; set; }
        public DbSet<StudentAttendSession> SessionAttendnces{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{


			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			modelBuilder.HasDefaultSchema(null);
			//modelBuilder.HasDefaultSchema(_schema);
			foreach (var entity in modelBuilder.Model.GetEntityTypes())
			{
				entity.SetSchema(_schema);
			}


		}
	}
}
