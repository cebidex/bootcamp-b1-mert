using System;
using System.ComponentModel.DataAnnotations;

namespace net_core_bootcamp_b1_mert.Models
{
    public class HWBook
    {
        public Guid? Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public string Publisher { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
