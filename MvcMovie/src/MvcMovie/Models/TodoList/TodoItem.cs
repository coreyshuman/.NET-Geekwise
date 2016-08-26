using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models.TodoList
{
    public class TodoItem
    {
        public int ID { get; set; }
        [Required, MaxLength(100), Display(Name="Todo")]
        public string Content { get; set; }
        public bool Completed { get; set; }
    }
}
