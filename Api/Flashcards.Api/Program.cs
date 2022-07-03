using Flashcards.DataAccess;
using Flashcards.Service.CategoryServices;
using Flashcards.Service.DeckServices;
using Flashcards.Service.FlashcardServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGetCategoryServiceModels, GetCategoryServiceModels>();
builder.Services.AddScoped<IUpsertCategoryCommand, UpsertCategoryCommand>();
builder.Services.AddScoped<IDeleteCategoryCommand, DeleteCategoryCommand>();
builder.Services.AddScoped<IGetFlashcardServiceModels, GetFlashcardServiceModels>();
builder.Services.AddScoped<IGetDeckServiceModels, GetDeckServiceModels>();
builder.Services.AddScoped<IUpsertDeckCommand, UpsertDeckCommand>();
builder.Services.AddScoped<IDeleteDeckCommand, DeleteDeckCommand>();
builder.Services.AddScoped<IDeleteFlashcardCommand, DeleteFlashcardCommand>();
builder.Services.AddScoped<IUpsertFlashcardCommand, UpsertFlashcardCommand>();

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
