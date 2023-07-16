using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Api.Infrastructures;
using PhoneBook.Report.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDependencyInjection();

builder.Services.AddDbContext<ReportContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PhoneBookDb"));
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
