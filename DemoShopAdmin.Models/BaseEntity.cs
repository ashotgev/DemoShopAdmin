using System;
using System.ComponentModel.DataAnnotations;

namespace DemoShopAdmin.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
