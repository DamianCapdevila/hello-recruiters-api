using HelloRecruiter.Models;

namespace HelloRecruiter.Repositories
{
	public class UserRepository
	{
		public static List<User> Users = new()
			{
				new() {Username="damian_admin", EmailAddress="damian.capdevila@hotmail.com", Password="MyPassword1234!",
					GivenName="Damian", Surname = "Capdevila", Role = "Administrator"},

				new() {Username="random_standard", EmailAddress="damian.capdevila@hotmail.com", Password="MyPassword1234!",
					GivenName="Random", Surname = "Random", Role = "Standard"},
			};
	}
}
