﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.DTOs
{
    public class GroupsDTO
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupType { get; set; }
        public string creatorId { get; set; }
    }
}
