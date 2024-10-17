

using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("PostId");
        builder.Property(x => x.CreatedDate).HasColumnName("CreateTime");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.Title).HasColumnName("Title").IsRequired();
        builder.Property(x => x.Content).HasColumnName("Content_Id");
        builder.Property(x => x.AuthorId).HasColumnName("AuthorId");
        builder.Property(x => x.CateogryId).HasColumnName("CategoryId");

        builder
            .HasOne(x => x.Author)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.CateogryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x=> x.Comments)
            .WithOne(x=> x.Post)
            .HasForeignKey(x=> x.PostId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
