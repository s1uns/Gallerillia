using DAL;
using Gallerillia.Server.BuildExtensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/logDay-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("------------------------------------------------------");
    Log.Information("------------------------------------------------------");
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();






    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSetSwagger();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddServices();
    builder.Services.AddSetSecurity(builder.Configuration);
    builder.Services.AddSetCors();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAutoMapper(typeof(Program).Assembly);
    builder.Services.AddDbSetup(builder.Configuration);




    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

    var app = builder.Build();
    app.InitializeDatabase();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors(CorsInjection.PolicyName);

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

