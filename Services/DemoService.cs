using IEnumerableVsIQueryable.Console.Helpers;
using IEnumerableVsIQueryable.Console.Repositories;

namespace IEnumerableVsIQueryable.Console.Services;

public class DemoService(IClienteRepository repository)
{
    public void EjecutarDemo()
    {
        EjecutarIQueryable();

        EjecutarIEnumerable();
    }

    private void EjecutarIQueryable()
    {
        PerformanceHelper.Measure("IQUERYABLE", () =>
        {
            var clientes = repository
                .ObtenerClientesQueryable()
                .Where(c => c.Ciudad == "CALI")
                .Where(c => c.Salario > 5000000)
                .OrderBy(c => c.Nombre)
                .Take(10)
                .ToList();

            System.Console.WriteLine($"Registros obtenidos: {clientes.Count}");

            foreach (var cliente in clientes)
            {
                System.Console.WriteLine(
                    $"{cliente.Id} - {cliente.Nombre} - {cliente.Ciudad} - {cliente.Salario}");
            }
        });
    }

    private void EjecutarIEnumerable()
    {
        PerformanceHelper.Measure("IENUMERABLE", () =>
        {
            var clientes = repository
                .ObtenerClientesEnumerable()
                .Where(c => c.Ciudad == "CALI")
                .Where(c => c.Salario > 5000000)
                .OrderBy(c => c.Nombre)
                .Take(10)
                .ToList();

            System.Console.WriteLine($"Registros obtenidos: {clientes.Count}");

            foreach (var cliente in clientes)
            {
                System.Console.WriteLine(
                    $"{cliente.Id} - {cliente.Nombre} - {cliente.Ciudad} - {cliente.Salario}");
            }
        });
    }
}