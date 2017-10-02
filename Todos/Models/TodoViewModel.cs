using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todos.Models
{
    public class TodoViewModel
    {
        public List<TodoItem> TodoItems { get; set; }

        public TodoViewModel()
        {
            TodoItems = new List<TodoItem>();
        }
    }
}