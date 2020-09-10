using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        
        public IActionResult GetAllTask(ToDoItemModel model)
        {
            var items = _toDoRepository.GetAllTask()
                .Select(Mapper.Map);
            
            return View("ShowTasks", items);
        }

        public IActionResult GiveAddTaskView() => View("AddTask");

        public IActionResult AddTask(ToDoItemModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return View();
            var item = Mapper.Map(model);
            _toDoRepository.AddTask(item);
            
            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult ChangeIsCompleted(int id, bool isCompleted)
        {
            _toDoRepository.ChangeIsCompleted(id, isCompleted);
            
            return RedirectToAction("GetAllTask");
        }

        public IActionResult StartEditTask(int id)
        {
            var item = _toDoRepository.GetById(id);
            var model = Mapper.Map(item);
            
            return View("EditTask", model);
        }
        
        public IActionResult EditTask(ToDoItemModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return View();
            
            _toDoRepository.EditTask(Mapper.Map(model));
            
            return RedirectToAction("GetAllTask");
        }

        public IActionResult RemoveTask(int id)
        {
            _toDoRepository.Remove(id);
            
            return RedirectToAction("GetAllTask");
        }
    }
}