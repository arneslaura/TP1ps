﻿using System;

namespace Domain.Entities
{
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Tasks> Tasks { get; set; }
    }
}
