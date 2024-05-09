using HelloRecruiter.Models;

namespace HelloRecruiter.Services
{
	public interface IRecruiterService
	{
		public List<Recruiter> List();
		public Recruiter Get(int id);
		public Task<Recruiter> Create(Recruiter recruiter);
		public Task<Recruiter> Update(Recruiter recruiter);
		public Task<bool> Delete(int id);
	}
}
