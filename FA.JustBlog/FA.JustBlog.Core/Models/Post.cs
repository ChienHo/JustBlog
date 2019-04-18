using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
   public class Post
   {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title name is required.")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("Short Description")]
        [Required(ErrorMessage = "Short Description is required.")]
        [StringLength(1024)]
        public string ShortDescription { get; set; }
        [StringLength(10240)]
        public string Description { get; set; }
        public string Meta { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        [Column("Posted On")]
        public DateTime? PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public string ImgUrl { get; set; }
        public int TotalRate { get; set; }
        [NotMapped]
        public decimal Rate { get; set; }
        public virtual IList<Tag> Tags { get; set; }
    }
}
