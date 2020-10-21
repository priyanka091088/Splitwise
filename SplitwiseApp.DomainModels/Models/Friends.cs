using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SplitwiseApp.DomainModels.Models
{
    public class Friends
    {
        [Key]
        public int friendId { get; set; }
        [Required]
        public string friendName { get; set; }
        [Required]
        public string Email { get; set; }
        public float Balance { get; set; }
        /*public string creatorId { get; set; }
        public string userId { get; set; }*/
    }
}
