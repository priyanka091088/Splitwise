using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class FriendsDTO
    {
        public string friendName { get; set; }
        public string Email { get; set; }
        public float Balance { get; set; }
        public string creatorId { get; set; }
        public string userId { get; set; }
    }
}
