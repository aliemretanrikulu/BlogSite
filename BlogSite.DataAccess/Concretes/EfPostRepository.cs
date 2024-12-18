﻿
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

    public List<Post> GettAllByAuthorId(string id)
    {
        return Context.Posts.Where(x=> x.AuthorId == id).ToList();
    }
}
