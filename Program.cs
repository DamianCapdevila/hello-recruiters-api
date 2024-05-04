using Microsoft.OpenApi.Models;
using RecruiterStore.DB;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Hello Recruiter API", 
        Description = "Greeting recruiters from all over the world!!", 
        Version = "v1",
        TermsOfService = new Uri("https://github.com/DamianCapdevila"),
        Contact = new OpenApiContact
        {
            Name = "Contact Damián Capdevila",
            Url = new Uri("https://www.linkedin.com/in/damiancapdevila/")
        }
        });
    options.EnableAnnotations();
});


var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(swaggerUI =>
    {
        swaggerUI.SwaggerEndpoint("/swagger/v1/swagger.json", "Hello Recruiter API V1");
    });


app.MapGet("/", () => "Hello Recruiters!!")
    .WithDescription("Gets a welcome message for all recruiters")
    .WithOpenApi();

app.MapGet("/recruiters/{id}", (int id) => RecruiterDB.GetRecruiter(id))
    .WithDescription("Gets a recruiter by its id")
    .WithOpenApi();

app.MapGet("/recruiters", () => RecruiterDB.GetRecruiters())
    .WithDescription("Gets all recruiters")
    .WithOpenApi();;

app.MapPost("/recruiters", (Recruiter recruiter) => RecruiterDB.CreateRecruiter(recruiter))
    .WithDescription("Creates a new recruiter")
    .WithOpenApi();;

app.MapPut("/recruiters", (Recruiter recruiter) => RecruiterDB.UpdateRecruiter(recruiter))
    .WithDescription("Updates a recruiter")
    .WithOpenApi();

app.MapDelete("/recruiters/{id}", (int id) => RecruiterDB.RemoveRecruiter(id))
    .WithDescription("Deletes a recruiter")
    .WithOpenApi();

app.Run();
