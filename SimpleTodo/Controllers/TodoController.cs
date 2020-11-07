using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleTodo.Models;
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
        public async Task<IActionResult> Index()
        {
            //get to-do items from database 
            
            var items = await _service.GetIncompleteItemsAsync();
            
            //put items into model
            
            var model = new TodoViewModel()
            {
                Items = items
            };

            //render view using model
            
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index");
            }

            var successful = await _service.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Couldn't add item");
            }

            return RedirectToAction("Index");
        }
    }
}
