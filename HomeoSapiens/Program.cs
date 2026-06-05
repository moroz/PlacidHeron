using HomeoSapiens.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddAppDb(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendAppPolicy",
        builder =>
        {
            builder
                .WithOrigins(["http://localhost:5173"])
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

app.UseCors("FrontendAppPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.MapControllers();

app.Run();