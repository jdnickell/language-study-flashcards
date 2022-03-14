var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlServer<Flashcards.Api.Models.FlashcardsContext>("Server=.\\SQLExpress;Database=Flashcards;Trusted_Connection=True;");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
