using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PersonDirectory.API.MiddleWare;
using PersonDirectory.Application.Interfaces;
using PersonDirectory.Application.Models;
using PersonDirectory.Application.Services;
using PersonDirectory.Application.Validators;
using PersonDirectory.Domain.Models;
using PersonDirectory.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<PersonPostDto>, PersonPostValidator>();
builder.Services.AddScoped<IValidator<PersonPutDto>, PersonPutValidator>();
builder.Services.AddScoped<IValidator<PhoneDto>, PhoneValidator>();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IConnectionRepository, ConnectionRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPhoneRepository, PhoneRepository>(); 
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddTransient<IFileService>(x => new FileService(imagePath: builder.Configuration.GetSection("ImagesFolder").GetValue<string>("Path", "")!));
builder.Services.AddLocalization();
// Register DbContext with Dependency Injection
builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCulture();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
