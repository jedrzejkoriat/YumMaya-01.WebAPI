using YumMaya_01.WebAPI.Application.Contracts.Persistence.Repositories;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence.Repositories;

internal sealed class NewsletterSubscriberRepository : GenericRepository<NewsletterSubscriber>, INewsletterSubscriberRepository
{
    public NewsletterSubscriberRepository(AppDbContext context) : base(context)
    {
    }
}