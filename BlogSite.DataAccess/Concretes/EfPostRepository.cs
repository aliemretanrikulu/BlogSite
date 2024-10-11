
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using Core.Repositories;
using BlogSite.Models.Entities;
using Post = BlogSite.Models.Entities.Post;

namespace BlogSite.DataAccess.Concretes;

public class EfPostRepository : EfRepositoryBase<BaseDbContext, Post, Guid>, IPostRepository
{
    public EfPostRepository(BaseDbContext context) : base(context)
    {
        
    }

}
