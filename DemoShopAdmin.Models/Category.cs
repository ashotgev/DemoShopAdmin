using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoShopAdmin.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int ParentId { get; set; }        
        public ICollection<Product> Products { get; set; }

    }
}
