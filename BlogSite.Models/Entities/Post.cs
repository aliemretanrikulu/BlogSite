using Core.Entitites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace BlogSite.Models.Entities;

public sealed class Post : Entity<Guid>
{

    public string Title { get; set; }

    public string Content { get; set; }

    public Category Category { get; set; }

    public int CateogryId { get; set; }

    public string AuthorId { get; set; }

    public User Author { get; set; }

    public List<Comment> Comments { get; set; }

}


