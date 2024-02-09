using Microsoft.EntityFrameworkCore;
using Student_Hobbies.Data;
using Student_Hobbies.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IHobbiesRepository,HobbiesRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<StudentRepository>(); // Assuming you have a StudentRepository class
builder.Services.AddScoped<HobbiesRepository>(); // Assuming you have a HobbiesRepository class

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
