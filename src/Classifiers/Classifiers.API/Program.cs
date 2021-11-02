using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Polly;
using Serilog;

using CDPN.Common;
using CDPN.Classifiers.Infrastructure;
using CDPN.Classifiers.Infrastructure.Data;
using System.Reflection;

const string AppName = "Classifiers.API";

#region Serilog configuration
var configuration = GetConfiguration();
var seqServerUrl = configuration["SeqServerUrl"];
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .WriteTo.Console()
    .WriteTo.File(Path.Combine(@".\\Logs", "Classifiers.API..txt"),
            rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 100000)
    //.WriteTo.Seq(seqServerUrl)
    .Enrich.WithProperty("ApplicationName", AppName)
    .CreateLogger();
#endregion

Log.Information($"Configuring web host ({AppName}...)");
var builder = WebApplication.CreateBuilder(args);
 
Log.Information($"Add services to the container...)");

builder.Host.UseSerilog();
//builder.Host.UseSerilog((context, services, configuration) => configuration
//                    .ReadFrom.Configuration(context.Configuration)
//                    .ReadFrom.Services(services)
//                    .Enrich.FromLogContext()
//                    .Enrich.WithProperty("ApplicationName", AppName)
//                    .WriteTo.Console()
//                    .WriteTo.File(Path.Combine(@".\\Logs", "Classifiers.API..txt"),
//                        rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 100000))
//                    //.WriteTo.Seq(seqServerUrl)
//                    ;

builder.Services.AddControllers();

#region Endpoint protected by authentication with JWT 
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.Authority = "https://login.microsoftonline.com/xxxxxxxxxxxxxxxxxxxxxxxxxx";
//    options.Audience = "xxxxxxxxxxxxxxxxxxxxxxxxx";
//    options.TokenValidationParameters.ValidateLifetime = false;
//    options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
//});
#endregion

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .SetIsOriginAllowed((host) => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CDPN:Classifiers API",
        Description = "Общие классификаторы CDPN (з даними українською мовою)",
        //TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Александр Шляхто",
            Email = string.Empty,
            Url = new Uri("https://infdev.com.ua"),
        },
        License = new OpenApiLicense
        {
            Name = "Используйте под MIT",
            Url = new Uri("https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt"),
        }
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);


    #region Swagger Security
    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
    //    Name = "Authorization",
    //    In = ParameterLocation.Header,
    //    Type = SecuritySchemeType.ApiKey,
    //    Scheme = "Bearer"
    //});
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            },
    //            Scheme = "oauth2",
    //            Name = "Bearer",
    //            In = ParameterLocation.Header,

    //        },
    //        new List<string>()
    //    }});
    #endregion
});

#region Add ClassifiersContext
var dbProvider = builder.Configuration.GetValue<string>("ClassifiersDbProvider");
var connectionString = builder.Configuration.GetValue<string>($"ClassifiersConnectionStrings:{dbProvider}");
switch(dbProvider)
{
    case DbProvider.Sqlite:
        builder.Services.AddDbContext<ClassifiersContext>(options =>
        {
            options.UseSqlite(connectionString,
                opt =>
                {
                    opt.MigrationsAssembly("CDPN.Classifiers.Infrastructure.Sqlite");
                    opt.MigrationsHistoryTable(DbContextConsts.MigrationsHistoryTableName);                    
                });
            options.EnableSensitiveDataLogging();
        });
        break;
    case DbProvider.SqlServer:
        builder.Services.AddDbContext<ClassifiersContext>(options =>
        {
            options.UseSqlServer(connectionString,
                opt =>
                {
                    opt.MigrationsAssembly("CDPN.Classifiers.Infrastructure.SqlServer");
                    opt.MigrationsHistoryTable(DbContextConsts.MigrationsHistoryTableName);
                });
        });
        break;
    case DbProvider.MySql:
        builder.Services.AddDbContext<ClassifiersContext>(options =>
        {
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23)),
                opt =>
                {
                    opt.MigrationsAssembly("CDPN.Classifiers.Infrastructure.MySql");
                    opt.MigrationsHistoryTable(DbContextConsts.MigrationsHistoryTableName);
                });
        });
        break;
    case DbProvider.PostgreSQL:
        builder.Services.AddDbContext<ClassifiersContext>(options =>
        {
            options.UseNpgsql(connectionString,
                opt =>
                {
                    opt.MigrationsAssembly("CDPN.Classifiers.Infrastructure.PostgreeSQL");
                    opt.MigrationsHistoryTable(DbContextConsts.MigrationsHistoryTableName);
                });
        });
        break;
    default:
        throw new NotSupportedException($"Invalid database provider: {dbProvider}");
}
#endregion

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger<Program>();
    try
    {
        logger.LogInformation($"Applying database context migrations ({AppName}:{nameof(ClassifiersContext)})...");
        // Apply database migration automatically. Note that this approach is not
        // recommended for production scenarios. Consider generating SQL scripts from
        // migrations instead.
        var retryPolicy = CreateRetryPolicy(configuration, logger);
        var context = scope.ServiceProvider.GetRequiredService<ClassifiersContext>();
        retryPolicy.Execute(context.Database.Migrate);

        logger.LogInformation($"Seeding data ({AppName})...");
        await ClassifiersContextSeed.SeedAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        logger.LogCritical(ex, $"Host terminated unexpectedly ({AppName})...");
        throw;
        //return 1;
    }
    finally
    {
        Log.CloseAndFlush();
    }

    logger.LogInformation($"Configure the HTTP request pipeline...");

    if (true || app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("CorsPolicy");

    app.UseHttpsRedirection();

    // app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    logger.LogInformation($"Starting web host ({AppName})...");
}
app.Run();


// Get primary configuration
static IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

// Migration policy
static Policy CreateRetryPolicy(IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger)
{
    var retryMigrations = false;
    bool.TryParse(configuration["RetryMigrations"], out retryMigrations);

    // Only use a retry policy if configured to do so.
    // When running in an orchestrator/K8s, it will take care of restarting failed services.
    if (retryMigrations)
    {
        return Policy.Handle<Exception>().
            WaitAndRetryForever(
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, retry, timeSpan) =>
                {
                    logger.LogWarning(
                        exception,
                        "Exception {ExceptionType} with message {Message} detected during database migration (retry attempt {retry})",
                        exception.GetType().Name,
                        exception.Message,
                        retry);
                }
            );
    }

    return Policy.NoOp();
}

