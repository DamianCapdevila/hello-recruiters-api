using HelloRecruiter.Models;

namespace HelloRecruiter.Services
{
	public interface IUserService
	{
		public User Get(UserLogin userLogin);
	}
}
