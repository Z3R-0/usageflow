using AccountService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Modules contain all needed services for this bounded context
builder.Services.AddAccountModule(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}


// Middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();


// Map endpoints
app.MapAccountEndpoints();

app.Run();

