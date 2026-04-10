using ERP.Application.Interfaces;
using ERP.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace ERP.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
            _repositories[type] = new GenericRepository<T>(_context);

        return (IGenericRepository<T>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public async Task BeginTransactionAsync()
        => _transaction = await _context.Database.BeginTransactionAsync();

    public async Task CommitTransactionAsync()
    {
        await _transaction!.CommitAsync();
        await _transaction.DisposeAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction!.RollbackAsync();
        await _transaction.DisposeAsync();
    }

    public void Dispose()
        => _context.Dispose();
}