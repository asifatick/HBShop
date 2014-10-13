using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        [Display(Name = "Category Name")]
        [Required]
        public String CategoryName { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}