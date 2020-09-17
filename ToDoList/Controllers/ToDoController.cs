using System;
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
                .Select(Mapper.Map).ToList();
            
            return View("ShowTasks", items);
        }

        public IActionResult AddTask(ToDoItemModel model)
        {
            if (!CheckModel(model))
                return View();
            var item = Mapper.Map(model);
            _toDoRepository.AddTask(item);
            
            return RedirectToAction(nameof(GetAllTask));
        }

        private bool CheckModel(ToDoItemModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("", "Name is required");
                return false;
            }
            if (model.Deadline != DateTime.MinValue && model.Deadline < DateTime.Now)
            {
                ModelState.AddModelError("", "Incorect date");
                return false;
            }
            return true;
        }
        
        public IActionResult ChangeIsCompleted(int id, bool isCompleted)
        {
            _toDoRepository.ChangeIsCompleted(id, isCompleted);
            
            return RedirectToAction("GetAllTask");
        }
        
        public IActionResult EditTask(ToDoItemModel model)
        {
            if (!CheckModel(model))
                return View();
            
            _toDoRepository.EditTask(Mapper.Map(model));
            
            return RedirectToAction("GetAllTask");
        }

        public IActionResult RemoveTask(int id)
        {
            Debug.WriteLine($"RemoveTask: id - {id}");
            _toDoRepository.Remove(id);
            
            return RedirectToAction("GetAllTask");
        }
    }
}