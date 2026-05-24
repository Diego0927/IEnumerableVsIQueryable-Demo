using IEnumerableVsIQueryable.Console.Data;
using IEnumerableVsIQueryable.Console.Repositories;
using IEnumerableVsIQueryable.Console.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

var inicio = DateTime.Now;

string logPath = Path.Combine(
    Directory.GetCurrentDirectory(),
    $"salida_{inicio:yyyyMMdd_HHmmss}.txt");

using var logWriter = new StreamWriter(logPath)
{
    AutoFlush = true
};

try
{
    Console.WriteLine("=======================================");
    Console.WriteLine("INICIO DEL PROCESO");
    Console.WriteLine($"Fecha inicio: {inicio:yyyy-MM-dd HH:mm:ss}");
    Console.WriteLine("=======================================\n");

    var stopwatch = Stopwatch.StartNew();

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    var services = new ServiceCollection();

    services.AddDbContext<AppDbContext>(options =>
    {
        options.UseOracle(
            configuration.GetConnectionString("OracleConnection"));

        options.EnableSensitiveDataLogging();

        options.LogTo(message =>
        {
            logWriter.WriteLine(message);
        });
    });

    services.AddScoped<IClienteRepository, ClienteRepository>();
    services.AddScoped<DemoService>();

    using var provider = services.BuildServiceProvider();

    Console.WriteLine("Resolviendo servicios...");

    var demo = provider.GetRequiredService<DemoService>();

    Console.WriteLine("Ejecutando benchmark...\n");

    demo.EjecutarDemo();

    stopwatch.Stop();

    Console.WriteLine("\n=======================================");
    Console.WriteLine("PROCESO FINALIZADO");
    Console.WriteLine($"Duración total: {stopwatch.Elapsed}");
    Console.WriteLine("=======================================");
}
catch (Exception ex)
{
    Console.WriteLine("\nERROR EN LA EJECUCIÓN:");
    Console.WriteLine(ex.Message);

    logWriter.WriteLine("\n========== ERROR ==========");
    logWriter.WriteLine(ex.ToString());
}
finally
{
    Console.WriteLine($"\nLog completo guardado en:");
    Console.WriteLine(logPath);

    Console.WriteLine("\nPresiona cualquier tecla para salir...");
    Console.ReadKey();
}