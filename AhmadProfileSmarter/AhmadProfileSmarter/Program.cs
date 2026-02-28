using AhmadDAL.Data;
using AhmadDAL.DataAccessLayer.AdminRequests;
using AhmadDAL.DataAccessLayer.Chats;
using AhmadDAL.DataAccessLayer.Credentials;
using AhmadDAL.DataAccessLayer.Dashboard;
using AhmadDAL.DataAccessLayer.Drive;
using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.DataAccessLayer.MeetingsVideo;
using AhmadDAL.DataAccessLayer.Profile;
using AhmadDAL.DataAccessLayer.Register;
using AhmadDAL.DataAccessLayer.ReportBug;
using AhmadDAL.DataAccessLayer.Tasks;
using AhmadService.Services.AdminRequests;
using AhmadService.Services.Chats;
using AhmadService.Services.Credentials;
using AhmadService.Services.Dashboard;
using AhmadService.Services.Drive;
using AhmadService.Services.Employees;
using AhmadService.Services.MeetingsVideo;
using AhmadService.Services.Profile;
using AhmadService.Services.Register;
using AhmadService.Services.ReportBug;
using AhmadService.Services.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<LoginRepository>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ReportbugRepository>();
builder.Services.AddScoped<ReportbugService>();
builder.Services.AddScoped<TasksRepository>();
builder.Services.AddScoped<TasksService>();
builder.Services.AddScoped<EmployeesRepository>();
builder.Services.AddScoped<EmployeesService>();
builder.Services.AddScoped<DriveRepository>();
builder.Services.AddScoped<DriveService>();
builder.Services.AddScoped<ChatsRepository>();
builder.Services.AddScoped<ChatsService>();
builder.Services.AddScoped<ProfileRepository>();
builder.Services.AddScoped<ProfileService>();
builder.Services.AddScoped<MeetingsVideoRepository>();
builder.Services.AddScoped<MeetingsVideoService>();
builder.Services.AddScoped<RegisterRepository>();
builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<DashboardRepository>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<AdminRequestsRepository>();
builder.Services.AddScoped<AdminRequestsService>();




builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // 🔑 JWT Bearer configuration for Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication("JwtBearer")
    .AddJwtBearer("JwtBearer", options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });


builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy
            .WithOrigins(
                "http://localhost:5173",
                "https://ahmadabdullahprofile.netlify.app"
            )
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.UseCors("AllowReact");

app.UseAuthentication();



app.UseAuthorization();

app.MapControllers();

app.Run();
