using IEnumerableVsIQueryable.Console.Data;
using IEnumerableVsIQueryable.Console.Entities;

namespace IEnumerableVsIQueryable.Console.Repositories;

public class ClienteRepository(AppDbContext context) : IClienteRepository
{
    private readonly AppDbContext _context = context;

    public IEnumerable<Cliente> ObtenerClientesEnumerable()
    {
        return [.. _context.Clientes];
    }

    public IQueryable<Cliente> ObtenerClientesQueryable()
    {
        return _context.Clientes.AsQueryable();
    }
}