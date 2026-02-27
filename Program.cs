using System.Reflection;

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

app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Server = Environment.MachineName }));


app.MapGet("/calculadora/soma", (int a, int b) => 
{
    // Simula uma lógica que pode receber fixes ou melhorias
    return Results.Ok(new { Resultado = a + b });
});

app.Run();
