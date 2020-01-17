using System;
using System.ComponentModel.DataAnnotations;

namespace net_core_bootcamp_b1_mert.DTOs
{
    public class HWBookAddDto
    {
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
    public class HWBookUpdateDto:HWBookAddDto
    {
        public Guid Id { get; set; }
    }
    public class HWBookGetDto
    {
        public Guid? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }
    }
}
