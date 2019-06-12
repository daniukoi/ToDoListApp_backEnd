using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace async_todo.DAL.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public string Task { get; set; }
    }
}
