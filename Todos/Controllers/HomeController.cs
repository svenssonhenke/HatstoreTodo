using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todos.Helpers;
using Todos.Models;

namespace Todos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var todoViewModel = new TodoViewModel();

            using (var session = DocumentStoreHelper.Store.OpenSession())
            {
                var loaded = session.Query<TodoItem>().ToArray();
                if (loaded.Any())
                {
                    todoViewModel.TodoItems.AddRange(loaded);
                }
            }
            return View(todoViewModel);
        }

        [HttpPost]
        public ActionResult Create(string createTodoText)
        {
            if(string.IsNullOrWhiteSpace(createTodoText))
            {
                return null;
            }
            var item = new TodoItem() {Text = createTodoText, Done = false };
            using (var session = DocumentStoreHelper.Store.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
            }
            return PartialView("~/Views/Shared/TodoItem.cshtml", item);
        }
        [HttpPost]
        public ActionResult SetDone(string itemId)
        {
            using (var session = DocumentStoreHelper.Store.OpenSession())
            {
                var loaded = session.Load<TodoItem>(itemId);
                if (loaded != null)
                {
                    loaded.Done = !loaded.Done;
                    session.Store(loaded);
                    session.SaveChanges();
                    return PartialView("~/Views/Shared/TodoItem.cshtml", loaded);
                }
            }
            return Json("false");
        }
        [HttpPost]
        public ActionResult Delete(string itemId)
        {
            using (var session = DocumentStoreHelper.Store.OpenSession())
            {
                var loaded = session.Load<TodoItem>(itemId);
                if (loaded != null)
                {
                    session.Delete(loaded);
                    session.SaveChanges();
                    return Json(true);
                }
            }
            return Json(false);
        }
    }
}