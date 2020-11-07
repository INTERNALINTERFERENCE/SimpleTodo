using Microsoft.AspNetCore.Mvc;
using SimpleTodo.Services;

namespace SimpleTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _service;
        public TodoController(ITodoItemService service)
        {
            _service = service;
        }
        public async IActionResult Index()
        {
            //get to-do items from database 

            var items = await _service.GetIncompleteItemsAsync();
            //put items into model

            //render view using model
        }
    }
}
