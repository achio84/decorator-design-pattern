using DecoratorDemoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<POSMalaysiaLocationService>();
//builder.Services.AddSingleton<ILocationService>(x => new CacheLocationService(x.GetRequiredService<POSMalaysiaLocationService>()));

builder.Services.AddHttpClient();
builder.Services.AddSingleton<ILocationService, POSMalaysiaLocationService>();
builder.Services.Decorate<ILocationService, CacheLocationService>();
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
