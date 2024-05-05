using HelloRecruiter.Models;
using HelloRecruiter.Repositories;

namespace HelloRecruiter.Services;

public class RecruiterService : IRecruiterService
{

	public List<Recruiter> List()
	{
		return RecruiterRepository.Recruiters;
	}

	public Recruiter Get(int id)
	{
		var recruiter = RecruiterRepository.Recruiters.SingleOrDefault(recruiter => recruiter.Id == id);
		if (recruiter == null) return null;
		return recruiter;
	}

	public Recruiter Create(Recruiter recruiter)
	{
		recruiter.Id = RecruiterRepository.Recruiters.Count + 1;
		RecruiterRepository.Recruiters.Add(recruiter);
		return recruiter;
	}

	public Recruiter Update(Recruiter newRecruiter)
	{
		var oldRecruiter = RecruiterRepository.Recruiters.FirstOrDefault(recruiter => recruiter.Id == newRecruiter.Id);
		if (oldRecruiter == null) return null;
		
		oldRecruiter.Id = newRecruiter.Id;
		oldRecruiter.Name = newRecruiter.Name;
		oldRecruiter.Email = newRecruiter.Email;
		oldRecruiter.Company = newRecruiter.Company;
		
		return newRecruiter;
	}

	public bool Delete(int id)
	{
		var oldRecruiter = RecruiterRepository.Recruiters.FirstOrDefault(recruiter => recruiter.Id == id);
		if (oldRecruiter == null) return false;
		
		RecruiterRepository.Recruiters.Remove(oldRecruiter);
		return true;
	}
}