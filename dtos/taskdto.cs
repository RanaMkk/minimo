﻿using static minimo.Models.Enums;

namespace minimo.dtos
{
    public class taskdto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }
    }
}
