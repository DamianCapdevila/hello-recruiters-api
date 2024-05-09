using HelloRecruiter.Data;
using HelloRecruiter.Models;
using HelloRecruiter.Repositories;

namespace HelloRecruiter.Services;

public class RecruiterService : IRecruiterService
{
	private readonly RecruitersDb _dbContext;

    public RecruiterService(RecruitersDb dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Recruiter> List()
	{
		return _dbContext.Recruiters.ToList();
	}

	public Recruiter Get(int id)
	{
		return _dbContext.Recruiters.FirstOrDefault(recruiter => recruiter.Id == id);
	}

	public async Task<Recruiter> CreateAsync(Recruiter recruiter)
	{
		_dbContext.Recruiters.Add(recruiter);
		await _dbContext.SaveChangesAsync();
		return recruiter;
	}

	public async Task<Recruiter> UpdateAsync(Recruiter newRecruiter)
	{
		var oldRecruiter = _dbContext.Recruiters.FirstOrDefault(recruiter => recruiter.Id == newRecruiter.Id);
		if (oldRecruiter != null)
		{
			_dbContext.Entry(oldRecruiter).CurrentValues.SetValues(newRecruiter);
			await _dbContext.SaveChangesAsync();
		}
		return newRecruiter;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var recruiter = _dbContext.Recruiters.FirstOrDefault(recruiter => recruiter.Id == id);
		if (recruiter != null)
		{
			_dbContext.Recruiters.Remove(recruiter);
			await _dbContext.SaveChangesAsync();	
			return true;
		}
		return false;
	}
}