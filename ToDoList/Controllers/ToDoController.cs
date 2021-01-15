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

        public IActionResult GetAllTask(ToDoItemModel model)
        {
            var items = _toDoRepository
                .GetAllTask()
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
            var isValid = true;
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError(nameof(ToDoItemModel.Name), "Name is required");
                isValid = false;
            }

            if (model.Deadline != null && model.Deadline < DateTime.Now)
            {
                ModelState.AddModelError(nameof(ToDoItemModel.Deadline), "Incorect date");
                isValid = false;
            }

            return isValid;
        }

        public IActionResult ChangeIsCompleted(int id, bool isCompleted)
        {
            _toDoRepository.ChangeIsCompleted(id, isCompleted);

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult EditTask(ToDoItemModel model)
        {
            if (!CheckModel(model))
                return View();

            _toDoRepository.EditTask(Mapper.Map(model));

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult RemoveTask(int id)
        {
            _toDoRepository.Remove(id);

            return RedirectToAction(nameof(GetAllTask));
        }
    }
}