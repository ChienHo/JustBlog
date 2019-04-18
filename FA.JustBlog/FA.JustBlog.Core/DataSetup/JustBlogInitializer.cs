using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FA.JustBlog.Core
{
    class JustBlogInitializer : DropCreateDatabaseIfModelChanges<JustBlogContext>
    {
        protected override void Seed(JustBlogContext context)
        {
            SeedData(context);
            base.Seed(context);
            Task.Run(async () => { await SeedAsync(context); }).Wait();
        }
        private static void SeedData(JustBlogContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Name = "C#",
                    Description = "C# Language",
                    UrlSlug = "Cshap"
                },
                new Category()
                {
                    Name = "HTML",
                    Description = "HTML frontEnd",
                    UrlSlug = "HTML"
                },
                new Category()
                {
                    Name = "API",
                    Description = "Web API",
                    UrlSlug = "API"
                },
                new Category()
                {
                    Name = "PHP",
                    Description = "PHP language",
                    UrlSlug = "PHP"
                }
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            List<Tag> tags = new List<Tag>()
            {
                new Tag()
                {
                 Name = "Hot",
                 Description = "Hot",
                 UrlSlug = "Hot",
                },
                new Tag()
                {
                    Name = "Good",
                    Description = "Good",
                    UrlSlug = "Good",
                },
                new Tag()
                {
                    Name = "Like",
                    Description = "Like",
                    UrlSlug = "Like",
                },
            };
            tags.ForEach(s => context.Tags.Add(s));
            context.SaveChanges();

            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Title = "HTML FrontEnd",
                    ShortDescription = "Hot HTML",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
                                  " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s," +
                                  " when an unknown printer took a galley of type and scrambled it to make a type specimen book." +
                                  " It has survived not only five centuries, but also the leap into electronic typesetting, " +
                                  "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages," +
                                  " and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",

                    Meta = "HTML",
                    UrlSlug = "HTML",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = null,
                    ViewCount = 12,
                    RateCount = 12,
                    TotalRate = 134,
                    CategoryId = 2,
                    Tags = tags,
                },
                new Post()
                {
                    Title = "PHP Language",
                    ShortDescription = "Hot HTML",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
                                  " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s," +
                                  " when an unknown printer took a galley of type and scrambled it to make a type specimen book." +
                                  " It has survived not only five centuries, but also the leap into electronic typesetting, " +
                                  "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages," +
                                  " and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",

                    Meta = "PHP",
                    UrlSlug = "PHP",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = null,
                    ViewCount = 14,
                    RateCount = 12,
                    TotalRate = 134,
                    CategoryId = 4,
                    Tags = tags,
                },
                new Post()
                {
                    Title = "C# Language",
                    ShortDescription = "Hot HTML",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
                                  " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s," +
                                  " when an unknown printer took a galley of type and scrambled it to make a type specimen book." +
                                  " It has survived not only five centuries, but also the leap into electronic typesetting, " +
                                  "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages," +
                                  " and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",

                    Meta = "PHP",
                    UrlSlug = "PHP",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = null,
                    ViewCount = 14,
                    RateCount = 12,
                    TotalRate = 134,
                    CategoryId = 1,
                    Tags = tags,
                }
            };
            posts.ForEach(s => context.Posts.Add(s));
            context.SaveChanges();
        }
        #region Add User and Role Identity

        private async Task SeedAsync(JustBlogContext context)
        {


            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var passwordHasher = new Microsoft.AspNet.Identity.PasswordHasher();

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Administrators"));
                await roleManager.CreateAsync(new IdentityRole("Contributor"));
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (!userManager.Users.Any(u => u.UserName == "admin@domain.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "admin@domain.com",
                    UserName = "admin@domain.com",
                    PasswordHash = passwordHasher.HashPassword("Abc@1234"),
                    EmailConfirmed = true,
                    PhoneNumber = "0944551356",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                await userManager.CreateAsync(user, "Abc@1234");
                await userManager.AddToRoleAsync(user.Id, "Administrators");
                await userManager.AddToRoleAsync(user.Id, "Contributor");
                await userManager.AddToRoleAsync(user.Id, "User");
            }

            if (!userManager.Users.Any(u => u.UserName == "Chien@domain.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "cong@domain.com",
                    UserName = "cong@domain.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0944551356",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                await userManager.CreateAsync(user, "Abc@1234");
                await userManager.AddToRoleAsync(user.Id, "Administrators");
            }

            if (!userManager.Users.Any(u => u.UserName == "van@domain.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "van@domain.com",
                    UserName = "van@domain.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0944551356",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                await userManager.CreateAsync(user, "Abc@1234");
                await userManager.AddToRoleAsync(user.Id, "Contributor");
            }

            if (!userManager.Users.Any(u => u.UserName == "quynh@domain.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "quynh@domain.com",
                    UserName = "quynh@domain.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0944551356",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                await userManager.CreateAsync(user, "Abc@1234");
                await userManager.AddToRoleAsync(user.Id, "User");
            }

            if (!userManager.Users.Any(u => u.UserName == "customer@domain.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "customer@domain.com",
                    UserName = "customer@domain.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0944551356",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                await userManager.CreateAsync(user, "Abc@1234");
                await userManager.AddToRoleAsync(user.Id, "User");
            }
        }
    }
    #endregion
}
