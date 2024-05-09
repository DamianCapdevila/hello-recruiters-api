using HelloRecruiter.Data;
using HelloRecruiter.Models;
using HelloRecruiter.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<RecruitersDb>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IRecruiterService, RecruiterService>();
builder.Services.AddScoped<IUserService, UserService>();

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

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer( options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
	};

});

builder.Services.AddAuthorization();




var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUI =>
{
    swaggerUI.SwaggerEndpoint("/swagger/v1/swagger.json", "Hello Recruiter API V1");
});

app.UseAuthorization();
app.UseAuthentication();


app.MapGet("/", () => "Hello Recruiters!!")
    .WithDescription("Gets a welcome message for all recruiters")
    .WithOpenApi();

app.MapPost("/login",
    (UserLogin user, IUserService service) => Login(user, service))
    .WithDescription("Provides a login mechanism")
	.WithOpenApi();

app.MapGet("/list", (IRecruiterService service) => List(service))
    .WithDescription("Gets all recruiters")
    .WithOpenApi();

app.MapGet("/get", 
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Standard,Administrator")]
    (int id, IRecruiterService service) => Get(id, service))
	.WithDescription("Gets a recruiter by its id")
    .WithOpenApi();;

app.MapPost("/create",
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
    (Recruiter recruiter, IRecruiterService service) => CreateAsync(recruiter, service))
    .WithDescription("Creates a new recruiter")
    .WithOpenApi();;

app.MapPut("/update",
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
    (Recruiter newRecruiter, IRecruiterService service) => UpdateAsync(newRecruiter, service))
    .WithDescription("Updates a recruiter")
    .WithOpenApi();

app.MapDelete("/delete",
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
    (int id, IRecruiterService service) => DeleteAsync(id, service))
    .WithDescription("Deletes a recruiter by its id")
    .WithOpenApi();


async Task<IResult> CreateAsync(Recruiter recruiter, IRecruiterService service)
{
    var result = await service.Create(recruiter);
    return Results.Ok(result);
}

IResult Get(int id, IRecruiterService service)
{
	var recruiter = service.Get(id);
    if (recruiter == null) return Results.NotFound("Recruiter not found.");
	return Results.Ok(recruiter);
}

IResult List(IRecruiterService service)
{
    var recruiter = service.List();
    return Results.Ok(recruiter);
}

async Task<IResult> UpdateAsync(Recruiter recruiter, IRecruiterService service)
{
    var updatedRecruiter = await service.Update(recruiter);
    if (updatedRecruiter == null) return Results.NotFound("Recruiter not found.");
    return Results.Ok(updatedRecruiter);
}

async Task<IResult> DeleteAsync(int id, IRecruiterService service)
{
    var result = await service.Delete(id);
    if (!result) return Results.BadRequest("Something went wrong.");
    return Results.Ok(result);
}

IResult Login(UserLogin user, IUserService service)
{
    if(!string.IsNullOrEmpty(user.Username)&&!string.IsNullOrEmpty(user.Password))
    {
        var loggedInUser = service.Get(user);
        if (loggedInUser == null) return Results.NotFound($"User {user.Username} not found.");

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
            new Claim(ClaimTypes.Email, loggedInUser.EmailAddress),
            new Claim(ClaimTypes.GivenName, loggedInUser.GivenName),
            new Claim(ClaimTypes.Surname, loggedInUser.Surname),
            new Claim(ClaimTypes.Role, loggedInUser.Role)
        };

        var token = new JwtSecurityToken
        (
            issuer: builder.Configuration["Jwt:Issuer"],
            audience: builder.Configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token); 
        
        return Results.Ok(tokenString);
    }

    return Results.BadRequest("User or Password is null.");
}

app.Run();
public partial class Program { }