using CardboardArchivistApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.CustomSchemaIds(model => model.FullName);
});

builder.Services.AddScoped<ICardService, InMemoryCardService>();
builder.Services.AddScoped<IReferenceService, InMemoryReferenceService>();
builder.Services.AddScoped<IDeckService, InMemoryDeckService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();