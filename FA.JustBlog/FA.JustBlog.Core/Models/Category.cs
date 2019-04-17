using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1024, ErrorMessage = "The Description must be between 5 and 1024 characters", MinimumLength = 5)]
        public string Description { get; set; }
        public virtual IList<Post> Posts { get; set; }
    }
}
