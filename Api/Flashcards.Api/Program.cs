using Flashcards.DataAccess;
using Flashcards.Service.CategoryServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGetCategoryServiceModels, GetCategoryServiceModels>();
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
