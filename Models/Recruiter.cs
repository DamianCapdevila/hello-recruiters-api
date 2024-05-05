namespace HelloRecruiter.Models;

public record Recruiter
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Company { get; set; }
    public string? Email { get; set; }
}
