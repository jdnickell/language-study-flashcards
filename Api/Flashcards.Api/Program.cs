using Flashcards.DataAccess;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var serviceProjectTypes = Assembly.GetAssembly(typeof(Flashcards.Service.Resources));

if (serviceProjectTypes != null)
{
    serviceProjectTypes.ExportedTypes
    .Where(t => t.IsClass)
    .SelectMany(t => t.GetInterfaces(), (c, i) => new { Class = c, Interface = i })
    .ToList()
    .ForEach(x => builder.Services.AddScoped(x.Interface, x.Class));
}

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSqlServer<FlashcardsContext>("Server=.\\SQLExpress;Database=Flashcards;Trusted_Connection=True;");
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
