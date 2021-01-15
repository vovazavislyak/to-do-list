using System;
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

        public IActionResult GetAllTask()
        {
            var items = _toDoRepository
                .GetAllTask()
                .Select(Mapper.Map).ToList();

            return View("ShowTasks", items);
        }

        public IActionResult AddTask(ToDoItemModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var item = Mapper.Map(model);
            _toDoRepository.AddTask(item);

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult ChangeIsCompleted(int id, bool isCompleted)
        {
            _toDoRepository.ChangeIsCompleted(id, isCompleted);

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult EditTask(ToDoItemModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _toDoRepository.EditTask(Mapper.Map(model));

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult RemoveTask(int id)
        {
            _toDoRepository.Remove(id);

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult ResetDeadline(ToDoItemModel model)
        {
            model.Deadline = null;

            return RedirectToAction(nameof(EditTask), model);
        }
    }
}