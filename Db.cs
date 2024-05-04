namespace RecruiterStore.DB; 

 public record Recruiter 
 {
   public int Id {get; set;} 
   public string ? Name { get; set; }
   public string ? Company { get; set; }
   public string ? Email { get; set; }
 }

 public class RecruiterDB
 {
   private static List<Recruiter> _recruiters = new List<Recruiter>()
   {
     new Recruiter{ Id=1, Name="Igor Hernández Irahola", Company="Celonis", Email="i.hernandeziraola@celonis.com"},
   };

   public static List<Recruiter> GetRecruiters() 
   {
     return _recruiters;
   } 


   public static Recruiter ? GetRecruiter(int id) 
   {
     return _recruiters.SingleOrDefault(recruiter => recruiter.Id == id);
   } 


   public static Recruiter CreateRecruiter(Recruiter recruiter) 
   {
     _recruiters.Add(recruiter);
     return recruiter;
   }


   public static Recruiter UpdateRecruiter(Recruiter update) 
   {
     _recruiters = _recruiters.Select(recruiter =>
     {
       if (recruiter.Id == update.Id)
       {
         recruiter.Name = update.Name;
       }
       return recruiter;
     }).ToList();
     return update;
   }

   public static void RemoveRecruiter(int id)
   {
     _recruiters = _recruiters.FindAll(recruiter => recruiter.Id != id).ToList();
   }
 }