using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Domain.Models;
using YumMaya_01.WebAPI.Infrastructure.Persistence;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;
public sealed class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(AppDbContext context) : base(context) { }
}