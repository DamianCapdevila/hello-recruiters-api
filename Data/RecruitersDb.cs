using HelloRecruiter.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloRecruiter.Data
{
	public class RecruitersDb : DbContext
	{
        public RecruitersDb(DbContextOptions<RecruitersDb> options) : base(options)
        {
            
        }

        public DbSet<Recruiter> Recruiters => Set<Recruiter>();
		public DbSet<User> Users => Set<User>();
		public DbSet<UserLogin> UsersLogin => Set<UserLogin>();
	}
}
