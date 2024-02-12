using CardboardArchivistAPI.Models.Collection;
using CardboardArchivistAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICardService, InMemoryCardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/card", (ICardService cardService) => cardService.GetAll());

app.MapGet("/card/{uuid}", (string uuid, ICardService cardService) => cardService.Get(uuid));

app.MapPost("/card", (Card card, ICardService cardService) => cardService.Create(card));

app.MapDelete("/card/{uuid}", (string uuid, ICardService cardService) => 
{
    if(cardService.Delete(uuid))
        return Results.NoContent();
    return Results.BadRequest();
});

app.MapPut("/card", (Card card, ICardService cardService) => cardService.Update(card));

app.Run();