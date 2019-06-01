using System;
using System.Collections.Generic;

namespace async_todo.Models
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public string Task { get; set; }
    }
}
