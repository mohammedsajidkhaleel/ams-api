using ams.api.Extensions;
using ams.application;
using ams.infrastructure;
using ams.infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var allowedOrigins = "allowedorigins";
builder.Services.AddCors(options =>
options.AddPolicy(name: allowedOrigins,
policy =>
{
    var corsOrigins = builder.Configuration.GetValue<string>("ApplicationSettings:AllowedCorsOrigins").Split(',');
    policy.WithOrigins("*").WithHeaders("*").WithMethods("*");
})
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

FastReport.Utils.Config.WebMode = true;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();
app.ApplyIdentityMigrations();

//app.UseHttpsRedirection();
//app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

app.UseCustomExceptionHandler();

app.UseCors(allowedOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<User>();
app.Run();
