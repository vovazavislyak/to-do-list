using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.ViewModels;

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

        public IActionResult AddTask(ToDoItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var item = Mapper.Map(viewModel);
            _toDoRepository.AddTask(item);

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult ChangeIsCompleted(int id, bool isCompleted)
        {
            _toDoRepository.ChangeIsCompleted(id, isCompleted);

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult EditTask(ToDoItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            _toDoRepository.EditTask(Mapper.Map(viewModel));

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult RemoveTask(int id)
        {
            _toDoRepository.Remove(id);

            return RedirectToAction(nameof(GetAllTask));
        }

        public IActionResult ResetDeadline(ToDoItemViewModel viewModel)
        {
            viewModel.Deadline = null;

            return RedirectToAction(nameof(EditTask), viewModel);
        }
    }
}