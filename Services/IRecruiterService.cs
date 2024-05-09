using HelloRecruiter.Models;

namespace HelloRecruiter.Services
{
	public interface IRecruiterService
	{
		public List<Recruiter> List();
		public Recruiter Get(int id);
		public Task<Recruiter> CreateAsync(Recruiter recruiter);
		public Task<Recruiter> UpdateAsync(Recruiter recruiter);
		public Task<bool> DeleteAsync(int id);
	}
}
