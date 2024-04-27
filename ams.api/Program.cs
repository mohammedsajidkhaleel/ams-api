using ams.infrastructure;
using ams.application;
using ams.api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var allowedOrigins = "allowedorigins";
builder.Services.AddCors(options =>
options.AddPolicy(name: allowedOrigins,
policy =>
{
    var corsOrigins = builder.Configuration.GetValue<string>("ApplicationSettings:AllowedCorsOrigins").Split(',');
    policy.WithOrigins(corsOrigins).WithHeaders("*").WithMethods("*");
})
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();

//app.UseHttpsRedirection();
app.UseCustomExceptionHandler();

app.UseCors(allowedOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
