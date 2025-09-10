using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Domain.Models;
using YumMaya_01.WebAPI.Infrastructure.Persistence;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;
public sealed class TagRepository : ITagRepository
{
    private readonly AppDbContext _context;

    public TagRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await _context.Set<Tag>().ToListAsync();
    }
}