using IEnumerableVsIQueryable.Console.Entities;

namespace IEnumerableVsIQueryable.Console.Repositories;

public interface IClienteRepository
{
    IEnumerable<Cliente> ObtenerClientesEnumerable();

    IQueryable<Cliente> ObtenerClientesQueryable();
}