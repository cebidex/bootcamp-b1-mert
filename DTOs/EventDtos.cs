using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_mert.DTOs
{
    public class EventAddDto
    {
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

    public class EventUpdateDto : EventAddDto
    {
        [Required]
        public Guid Id { get; set; }
    }

    public class EventGetDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Location { get; set; }
        public bool isFree { get; set; }
        public double Price { get; set; }
        public string Subject { get; set; }
        public string Desc { get; set; }
    }
}
