using System;
using System.ComponentModel.DataAnnotations;

namespace net_core_bootcamp_b1_mert.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime FinishDate { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public bool isFree { get; set; }
        public double Price { get; set; }
        public string Subject { get; set; }
        public string Desc { get; set; }
    }
}