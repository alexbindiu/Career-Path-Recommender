using Microsoft.EntityFrameworkCore;
using CareerPathRecommender.Data;
using CareerPathRecommender.Repositories;
using CareerPathRecommender.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connStr"))
);

builder.Services.AddHttpClient<AiService>();
builder.Services.AddScoped<SkillsRepository>();
builder.Services.AddScoped<SkillsService>();

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

app.UseCors((x) => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
