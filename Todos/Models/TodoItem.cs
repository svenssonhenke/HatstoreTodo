using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todos.Models
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
    }
}