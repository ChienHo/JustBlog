using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FA.JustBlog.Core
{
  public class JustBlogContext: IdentityDbContext
    {
        public JustBlogContext() : base("JustBlogContext")
        {
            Database.SetInitializer(new JustBlogInitializer());
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public static JustBlogContext Create()
        {
            return new JustBlogContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany<Tag>(p => p.Tags)
                .WithMany(t => t.Posts)
                .Map(pt =>
                {
                    pt.MapLeftKey("PostId");
                    pt.MapRightKey("TagId");
                    pt.ToTable("PostTagMap");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
