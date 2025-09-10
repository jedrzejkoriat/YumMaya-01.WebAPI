using Microsoft.EntityFrameworkCore.Storage;
using YumMaya_01.WebAPI.Application.Contracts.Persistence;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence;

public sealed class EfUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;

    public EfUnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync() => _transaction = await _context.Database.BeginTransactionAsync();
    public async Task CommitAsync() => await _transaction!.CommitAsync();
    public async Task RollbackAsync() => await _transaction!.RollbackAsync();
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}