var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/soma", () => 2 + 1);

app.MapGet("/version", () => 
{
    var version = Assembly.GetEntryAssembly()
                          ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                          ?.InformationalVersion;
                          
    return Results.Ok(new { 
        Version = version, 
        BuildDate = DateTime.UtcNow 
    });
});

app.Run();
