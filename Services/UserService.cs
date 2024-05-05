using HelloRecruiter.Models;
using HelloRecruiter.Repositories;

namespace HelloRecruiter.Services
{
	public class UserService : IUserService
	{
		public User Get(UserLogin userLogin)
		{
				User user = UserRepository.Users.FirstOrDefault(user => user.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) &&
															    user.Password.Equals(userLogin.Password));
				return user;
		}
	}
}
