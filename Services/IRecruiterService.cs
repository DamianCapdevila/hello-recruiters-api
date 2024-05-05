using HelloRecruiter.Models;

namespace HelloRecruiter.Services
{
	public interface IRecruiterService
	{
		public List<Recruiter> List();
		public Recruiter Get(int id);
		public Recruiter Create(Recruiter recruiter);
		public Recruiter Update(Recruiter recruiter);
		public bool Delete(int id);
	}
}
