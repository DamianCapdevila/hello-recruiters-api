using HelloRecruiter.Models;

namespace HelloRecruiter.Repositories
{
	public class RecruiterRepository
	{
		public static List<Recruiter> Recruiters = new List<Recruiter>()
		{
			   new Recruiter{ Id=1, Name="Igor Hernández Irahola", Company="Celonis", Email="i.hernandeziraola@celonis.com"},
			   new Recruiter{ Id=2, Name="Any future recruiter", Company="Any company", Email="any.recruiter@any.company.com"}
		};
	}
}
